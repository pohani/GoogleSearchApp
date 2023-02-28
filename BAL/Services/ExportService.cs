using BAL.IServices;
using DAL.IConfiguration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ExportService : IExportService
    {

        private readonly IUnitOfWork _uow;
        private readonly MyConfigurationApi _myConfig;
        private readonly ISearchService SearchService;

        public ExportService(IUnitOfWork unitOfWork, MyConfigurationApi myConfiguration, ISearchService searchService)
        {
            _uow = unitOfWork;
            _myConfig = myConfiguration;
            SearchService = searchService;
        }

        public ExcelPackage GetExcel(string word, string? filter)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            ExcelPackage package = new ExcelPackage();

            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("ResultsFromGoogle");

            sheet.Cells[1, 1].LoadFromCollection(SearchService.Search(word, filter).ToList());

            return package;
        }
    }
}
