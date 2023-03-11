using Microsoft.EntityFrameworkCore;

namespace Bits_Orchestra_test.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ExcelModel> excels { get; set; }
    }
}
