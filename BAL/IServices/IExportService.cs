using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IExportService
    {
        ExcelPackage GetExcel(string word, string? filter);
    }
}
