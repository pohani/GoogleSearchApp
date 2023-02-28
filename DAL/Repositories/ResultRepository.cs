using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        public ResultRepository(SDbContext sDbContext) : base(sDbContext)
        { 
        }


        public IEnumerable<Result> GetAll()
        {
            return _sDbContext.Results.ToList();

        }

        public void Add(Result _object)
        {
            _sDbContext.Results.Add(_object);
        }


        public Result GetById(int Id)
        {
            return _sDbContext.Results.Find(Id);
        }

        public void Delete(Result _object)
        {
            _sDbContext.Results.Remove(_object);
        }

        public void AddAll(IEnumerable<Result> results)
        {
            _sDbContext.Results.AddRange(results);
        }

        public IEnumerable<Result> GetByKeyWordId(int keyWordId)
        {
            return _sDbContext.Results.Where(x => x.KeyWord.Id == keyWordId).ToList();

        }

        public IEnumerable<Result> GetByKeyWordIdWithFilter(int keyWordId, string filterWord)
        {
            return _sDbContext.Results.Where(x => x.KeyWord.Id == keyWordId && (x.Title.Contains(filterWord) || x.Name.Contains(filterWord) || x.Content.Contains(filterWord) || x.Link.Contains(filterWord))).ToList();
        }

    }
}
