using Microsoft.AspNetCore.Http;
using newExcelsiorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace newExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VoyagesController : ControllerBase
  {
    SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");
    [HttpGet]
    [Route("getVoyages")]
    public IActionResult getVoyages()
    {
      List<Voyage> Voyages = new List<Voyage>();
      SqlDataReader reader;
      SqlCommand getVoyages = new SqlCommand("select * from Voyages where departure > @now order by departure asc",con);
      getVoyages.Parameters.AddWithValue("@now",DateTime.Now);

      try
      {
        con.Open();
        reader = getVoyages.ExecuteReader();

        while (reader.Read())
        {
          Voyage voyage = new Voyage();
          voyage.Id = Convert.ToInt32(reader[0]);
          voyage.ShipId = Convert.ToInt32(reader[1]);
          voyage.Departure = Convert.ToDateTime(reader[2]);
          voyage.Arrival = Convert.ToDateTime(reader[3]);
          voyage.RoomsAvailable = Convert.ToInt32(reader[4]);
          voyage.TotalRooms = Convert.ToInt32(reader[5]);
          voyage.Destination = reader[6].ToString();
          Voyages.Add(voyage);
        }
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }

      

      foreach(Voyage voyage in Voyages)
      {
        SqlCommand getShip = new SqlCommand("select * from cruiseShip where Id = @shipId", con);
        getShip.Parameters.AddWithValue("@shipId", voyage.ShipId);
        voyage.CruiseShip = new CruiseShip();
        try
        {
          con.Open();
          reader = getShip.ExecuteReader();
          reader.Read();
          voyage.CruiseShip.Id = Convert.ToInt32(reader[0]);
          voyage.CruiseShip.PortCity = reader[1].ToString();
          voyage.CruiseShip.PortState = reader[2].ToString();
          voyage.CruiseShip.ShipName = reader[3].ToString();
          voyage.CruiseShip.CruiseLine = reader[4].ToString();
          voyage.CruiseShip.AdultPrice = Convert.ToDecimal(reader[5]);
          voyage.CruiseShip.ChildPrice = Convert.ToDecimal(reader[6]);
          voyage.CruiseShip.RoomPrice = Convert.ToDecimal(reader[7]);
          voyage.CruiseShip.TripLength = Convert.ToInt32(reader[8]);
          voyage.CruiseShip.Img1 = reader[9].ToString();
          voyage.CruiseShip.Img2 = reader[10].ToString();
          voyage.CruiseShip.Img3 = reader[11].ToString();
          voyage.CruiseShip.Img4 = reader[12].ToString();
        }
        catch(Exception ex) { throw new Exception(ex.Message); }
        finally { con.Close(); }

        SqlCommand getShipItinerary = new SqlCommand("select * from Itinerary where shipId = @shipId", con);
        getShipItinerary.Parameters.AddWithValue("@shipId", voyage.CruiseShip.Id);

        try
        {
          con.Open();
          reader = getShipItinerary.ExecuteReader();
          while(reader.Read())
          {
            Itinerary Itinerary = new Itinerary();
            Itinerary.ShipId = Convert.ToInt32(reader[0]);
            Itinerary.Day = Convert.ToInt32(reader[1]);
            Itinerary.City = reader[2].ToString();
            Itinerary.StateCountry = reader[3].ToString();
            Itinerary.PortTime = reader[4].ToString();
            voyage.CruiseShip.Itineraries.Add(Itinerary);
          }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        finally { con.Close(); }
      }
      return Ok(Voyages);
    }

    
  }
}
