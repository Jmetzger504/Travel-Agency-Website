using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newExcelsiorAPI.Models;
using System.Data.SqlClient;

namespace newExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CruiseShipController : ControllerBase
  {
    [HttpGet]
    [Route("getLocations")]
    public IActionResult getLocations()
    {

      SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");
      SqlDataReader reader;
      SqlCommand getLocations = new SqlCommand("select distinct destination from Voyages",con);
      List<string>? locations = new List<string>();
      try
      {
        con.Open();
        reader = getLocations.ExecuteReader();
        while (reader.Read()) 
        locations.Add(reader[0].ToString());

        return Ok(locations);
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }
    }

    
    
  }
}
