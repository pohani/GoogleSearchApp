using BAL.IServices;
using DAL.IConfiguration;
using DAL.Models;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _uow;
        private readonly MyConfigurationApi _myConfig;

        public SearchService(IUnitOfWork unitOfWork, MyConfigurationApi myConfiguration)
        {
            _uow = unitOfWork;
            _myConfig = myConfiguration;
        }

        public IEnumerable<Result> Search(string word, string? filter)
        {
            if(word.IsNullOrEmpty()) return new List<Result>();

            try { 
                var apiKey = _myConfig.apiKey;
                var searchEngineId = _myConfig.searchEngineId;

                if (apiKey.IsNullOrEmpty() || searchEngineId.IsNullOrEmpty())
                {
                    return new List<Result>();
                }

                var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
                var listRequest = customSearchService.Cse.List();
                listRequest.Q = word;
                listRequest.Cx = searchEngineId;

                List<Result> dataModel = new List<Result>();
                var count = 0;

                KeyWord keyWord = _uow.KeyWordRepository.GetByWord(word);

                if (keyWord == null)
                {
                    keyWord = new KeyWord() { Word = word };

                    while (dataModel != null)
                    {
                        listRequest.Start = count;
                        listRequest.Execute().Items?.ToList().ForEach(x => dataModel.Add(new Result
                        {
                            Content = x.Snippet,
                            Link = x.Link,
                            Title = x.Title,
                            Name = x.HtmlTitle,
                            KeyWord = keyWord,
                        }));
                        count++;
                        if (count >= 10)
                        {
                            break;
                        }
                    }

                    keyWord.Results = dataModel;

                    _uow.KeyWordRepository.Add(keyWord);
                    _uow.ResultDataModelRepository.AddAll(dataModel);
                    _uow.Complete();
                }
                else
                {
                    if (filter.IsNullOrEmpty())
                    {
                        dataModel = _uow.ResultDataModelRepository.GetByKeyWordId(keyWord.Id).ToList();
                    }
                }

                if (!filter.IsNullOrEmpty())
                {
                    dataModel = _uow.ResultDataModelRepository.GetByKeyWordIdWithFilter(keyWord.Id, filter).ToList();
                }

                return dataModel;
            } 
            catch(Exception ex)
            {
                return new List<Result>();
            }
        }
    }
}
