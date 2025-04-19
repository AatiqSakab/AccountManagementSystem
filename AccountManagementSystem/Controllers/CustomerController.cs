using AccountManagementSystem.Data;
using AccountManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountManagementSystem.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public CustomerController(ApplicationDbContext dbContext)
        {
           this.dbcontext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await dbcontext.Customers.ToListAsync();
            return Ok(customers);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await dbcontext.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await dbcontext.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto addCustomerDto)
        {
            var customer = new Customer
            {
                FirstName = addCustomerDto.FirstName,
                LastName = addCustomerDto.LastName,
                Email = addCustomerDto.Email
            };
            await dbcontext.Customers.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            dbcontext.Entry(customer).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await dbcontext.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            dbcontext.Customers.Remove(customer);
            await dbcontext.SaveChangesAsync();
            return Ok(customer);

        } 
    }
}
