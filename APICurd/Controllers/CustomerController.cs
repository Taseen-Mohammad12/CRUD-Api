using APICurd.Data;
using APICurd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICurd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public CustomerController(ApiDbContext ApiDbContext)
        {
            this.dbContext =ApiDbContext;

        }
        
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
          return Ok (await dbContext.Customers.ToListAsync());
           
          
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult>GetByID([FromRoute] int id)
        {
            var Customer = await dbContext.Customers.FindAsync(id);

            if(Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id,Customer customer)
        {
            if(id != customer.Id)
                return BadRequest();
            dbContext.Entry(customer).State = EntityState.Modified;
            return Ok(customer);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id , Customer customer)
        {
            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }

    }
}
