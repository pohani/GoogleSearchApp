using BAL.IServices;
using BAL.Services;
using System.Web;
using Microsoft.AspNetCore.Http;
using DAL.IConfiguration;
using DAL.Models;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using GoogleSearchApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Azure;

namespace GoogleSearchApp.Controllers
{
    public class SearchController : Controller
    {
        private const String EXCEL_FILENAME = "ResultsFromGoogle.xlsx";
        private readonly ISearchService SearchService;
        private readonly IExportService ExportService;


        public SearchController(ISearchService iSearchService, IExportService exportService)
        {
            SearchService = iSearchService;
            ExportService = exportService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new SearchViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            model.Results = SearchService.Search(model.SearchWord, model.filterWord).ToList();
            
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(60),
                HttpOnly = true
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Excel(SearchViewModel model)
        {
            MemoryStream memStram = new MemoryStream();

            ExportService.GetExcel(model.SearchWord, model.filterWord).SaveAs(memStram);

            memStram.Position = 0;

            return File(memStram, "application/octet-stream", EXCEL_FILENAME);
        }

    }
}
