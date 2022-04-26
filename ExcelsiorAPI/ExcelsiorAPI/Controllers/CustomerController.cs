using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelsiorAPI.Models.EF;

namespace ExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    excelsiorDbContext dbContext = new excelsiorDbContext();

    [HttpGet]
    [Route("{email}/{password}")]
    public IActionResult Login(string email, string password)
    {
      try
      {
        var customerCount = (from e in dbContext.Customers
                             where e.Email == email && e.Password == password
                             select e).Count();
        if (customerCount == 0)
          return NoContent();

        var customer = (from e in dbContext.Customers
                        where e.Email == email && e.Password == password
                        select e);
        return Ok(customer);

      }
      catch (Exception ex) { throw new Exception(ex.Message); }
    }

    [HttpPost]
    [Route("Register/")]
    public IActionResult Register(Customer customer)
    {

      try
      {
        var customerCount = (from e in dbContext.Customers
                             where e.Email == customer.Email
                             select e).Count();
        if (customerCount == 0)
        {
          var maxCustomerId = (from e in dbContext.Customers
                               select e.Id).Max();
          customer.Id = maxCustomerId + 1;
          dbContext.Customers.Add(customer);
          dbContext.SaveChanges();
          return Created("Registration successful!", customer);
        }
        else return Conflict();
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
    }

  }

}

