using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newExcelsiorAPI.Models;
using System.Data.SqlClient;

namespace newExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerDetailsController : ControllerBase
  {
    SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");

    [HttpGet]
    [Route("{email}/{password}")]
    public IActionResult Login(string email,string password)
    {
      bool authenticated;
      Customer customer = new Customer();

      try
      {
        authenticated = customer.attemptLogin(email,password);
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
      
      if(authenticated)
      {
        customer = customer.login(email,password);
        return Ok(customer);
      }
      return NoContent();
    }

    [HttpPost]
    [Route("Register/")]
    public IActionResult Register(Customer customer)
    {
      bool authenticated;
      try
      {
        authenticated = customer.attemptLogin(customer.Email,customer.Password);
      }
      catch (Exception ex) { throw new Exception(ex.Message); }

      if(!authenticated)
      {
        try {
          customer.register();
          return Created("",customer);
        }
        catch(Exception ex) { throw new Exception(); }

        
      }

      return NoContent();
    }

    [HttpPost]
    [Route("purchaseTicket/")]
    public IActionResult purchase(CruiseTicket ticket)
    {

      
      SqlCommand purchaseTicket = new SqlCommand("insert into cruiseTicket (voyageId,custID,shipID,Rooms,childGuests,adultGuests,totalCost) values (@voyageId,@custID,@shipID,@Rooms,@childGuests,@adultGuests,@totalCost)",con);
      purchaseTicket.Parameters.AddWithValue("@voyageId",ticket.VoyageId);
      purchaseTicket.Parameters.AddWithValue("@custID",ticket.CustId);
      purchaseTicket.Parameters.AddWithValue("@shipID",ticket.ShipId);
      purchaseTicket.Parameters.AddWithValue("@Rooms",ticket.Rooms);
      purchaseTicket.Parameters.AddWithValue("@childGuests",ticket.ChildGuests);
      purchaseTicket.Parameters.AddWithValue("@adultGuests",ticket.AdultGuests);
      purchaseTicket.Parameters.AddWithValue("@totalCost",ticket.TotalCost);
      try
      {
        con.Open();
        purchaseTicket.ExecuteNonQuery();
        return Created("",ticket);
      }
      catch(Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }  
    }

  }
}
