using Bits_Orchestra_test.Models.Coverters;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bits_Orchestra_test.Models
{
    public class ExcelModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth{ get; set; }
        public bool IsMarried { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
