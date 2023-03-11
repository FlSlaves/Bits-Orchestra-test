using CsvHelper;
using CsvHelper.Configuration;
using System.Runtime.CompilerServices;

namespace Bits_Orchestra_test.Models
{
    public class ExcelMap : ClassMap<ExcelModel>
    {
        public ExcelMap()
        {
            Map(m => m.ID).Ignore();
            Map(m => m.Name).Name("Name");
            Map(m => m.DateOfBirth).Name("Date of birth");
            Map(m => m.IsMarried).Name("Married");
            Map(m => m.Phone).Name("Phone");
            Map(m => m.Salary).Name("Salary");         
        }
    }
}
