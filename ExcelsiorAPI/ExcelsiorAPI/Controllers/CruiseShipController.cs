using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelsiorAPI.Models.EF;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.SqlClient;
namespace ExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CruiseShipController : ControllerBase
  {
    excelsiorDbContext dbContext = new excelsiorDbContext();
    //Fine, I'll do it myself.
    SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");
    

    [HttpGet]
    [Route("getLocations")]
    public IActionResult getLocations()
    {
      try
      {
        var locations = (from e in dbContext.CruiseShips
                         select e.Destination).Distinct();
        return Ok(locations);
      }
      catch (Exception ex) { throw new Exception(); }
    }

    [HttpGet]
    [Route("SearchByLocation/{location}")]
    public IActionResult SearchByLocation(string location)
    {
      List<CruiseShip> Cruises = new List<CruiseShip>();
      
      
      try { Cruises = dbContext.CruiseShips.Where(e => e.Destination == location).ToList(); }
      catch (Exception ex) { throw new Exception("No Matching Ships"); }
      
      
      //  foreach (CruiseShip ship in Cruises)
      //  {
      //    List<Voyage> Voyages = new List<Voyage>();
      //    List<Itinerary> itineraries = new List<Itinerary>();
      //    SqlDataReader reader;
      //    SqlCommand getVoyages = new SqlCommand("select * from Voyages where shipId = @shipId", con);
      //    getVoyages.Parameters.AddWithValue("@shipid", ship.Id);

      //    try
      //  {
      //    con.Open();
      //    reader = getVoyages.ExecuteReader();

      //    while(reader.Read())
      //    {
      //      Voyage voyage = new Voyage();
      //      voyage.Arrival = Convert.ToDateTime(reader["arrival"]);
      //      voyage.Departure = Convert.ToDateTime(reader["departure"]);
      //      voyage.ShipId = ship.Id;
      //      voyage.Id = Convert.ToInt32(reader["Id"]);
      //      Voyages.Add(voyage);
      //    }
      //    ship.Voyages = Voyages;

          
      //  }
      //  catch(Exception ex) { throw new Exception("Voyages failure."); }
      //  finally { con.Close(); }

      //  SqlCommand getItinerary = new SqlCommand("select * from Itinerary where shipId = @shipId", con);
      //  getItinerary.Parameters.AddWithValue("@shipId", ship.Id);

      //  try
      //  {
      //    con.Open();
      //    reader = getItinerary.ExecuteReader();

      //    while (reader.Read())
      //    {
      //      Itinerary itinerary = new Itinerary();
      //      itinerary.ShipId = ship.Id;
      //      itinerary.Day = Convert.ToInt32(reader["day"]);
      //      itinerary.City = reader["city"].ToString();
      //      itinerary.StateCountry = reader["stateCountry"].ToString();
      //      itinerary.PortTime = reader["portTime"].ToString();
      //      itineraries.Add(itinerary);

      //    }

      //    ship.Itineraries = itineraries;

      //  }
      //  catch (Exception ex) { throw new Exception("Itinerary failure"); }
      //  finally { con.Close(); }
      //} 
      
      


      
        
      return Ok(Cruises);
    }

    [HttpGet]
    [Route("SearchByDate/{start}/{end}")]
    public IActionResult SearchByDate(DateTime start, DateTime end)
    {
      try
      {
        var voyages = dbContext.Voyages.Where(e => e.Departure > start && e.Arrival < end)
          .Include(d => d.Ship);

        return Ok(voyages);
      }
      catch (Exception ex) { throw new Exception(); }
    }

  }
}
