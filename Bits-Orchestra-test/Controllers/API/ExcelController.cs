using Bits_Orchestra_test.Models;
using Bits_Orchestra_test.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bits_Orchestra_test.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public ExcelController(AppDbContext appDbcontext)
        {
            this.appDbContext = appDbcontext;
        }
        // GET: api/<ValuesController>

        [HttpGet]
        public List<ExcelModel> Get()
        {
            return appDbContext.excels.ToList();
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void CreateRecord([FromBody] ExcelModel value)
        {
            
            var model = new ExcelModel
            {
                Name = value.Name,
                DateOfBirth = value.DateOfBirth,
                IsMarried = value.IsMarried,
                Phone = value.Phone,
                Salary = value.Salary,
            };
            appDbContext.excels.Add(model);
            appDbContext.SaveChanges();
        }

        //PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRecord(int id, [FromBody] ExcelModel value)
        {
            var update = appDbContext.excels.FirstOrDefault(e => e.ID == id);
            if (update == null)
                return NotFound();
            update.Name = value.Name;
            update.DateOfBirth = value.DateOfBirth;
            update.IsMarried = value.IsMarried;
            update.Phone = value.Phone;
            update.Salary = value.Salary;
            appDbContext.SaveChanges();
            return Ok(update);
        }

        // DELETE api/<ValuesController>/5

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await appDbContext.excels.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            appDbContext.excels.Remove(item);
            await appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
