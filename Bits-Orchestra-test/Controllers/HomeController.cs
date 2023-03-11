using Bits_Orchestra_test.Models;
using Bits_Orchestra_test.Models.Data;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace Bits_Orchestra_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("File is required");
            }

            if (!Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only CSV files are allowed");
            }

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                
            };
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<ExcelMap>();
                csv.Context.TypeConverterOptionsCache.GetOptions<bool>().BooleanTrueValues.Add("Yes");
                csv.Context.TypeConverterOptionsCache.GetOptions<bool>().BooleanFalseValues.Add("No");
                var records = csv.GetRecords<ExcelModel>().ToList();
                await appDbContext.AddRangeAsync(records);
                await appDbContext.SaveChangesAsync();

            }
            return Ok();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}