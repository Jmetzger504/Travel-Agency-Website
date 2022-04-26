using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newExcelsiorAPI.Models;
using System.Data.SqlClient;

namespace newExcelsiorAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CruiseTicketController : ControllerBase
  {
    SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");

    [HttpGet]
    [Route("getMyTickets{custId}")]
    public IActionResult getMyTickets(int custId)
    {
      List<CruiseTicket> myTickets = new List<CruiseTicket>();

      SqlCommand getMyTickets = new SqlCommand("select * from cruiseTicket where custID = @custID", con);
      getMyTickets.Parameters.AddWithValue("@custID",custId);
      SqlDataReader reader;

      try
      {
        con.Open();
        reader = getMyTickets.ExecuteReader();

        while(reader.Read())
        {
          CruiseTicket ticket = new CruiseTicket();
          ticket.Id = Convert.ToInt32(reader[0]);
          ticket.VoyageId = Convert.ToInt32(reader[1]);
          ticket.CustId = Convert.ToInt32(reader[2]);
          ticket.ShipId = Convert.ToInt32(reader[3]);
          ticket.Rooms = Convert.ToInt32(reader[4]);
          ticket.ChildGuests = Convert.ToInt32(reader[5]);
          ticket.AdultGuests = Convert.ToInt32(reader[6]);
          ticket.TotalCost = Convert.ToDecimal(reader[7]);
          myTickets.Add(ticket);
        }
      }
      catch (Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }

      if (myTickets == null)
        return NoContent();

      foreach(CruiseTicket ticket in myTickets)
      {
        SqlCommand getTicketVoyage = new SqlCommand("select * from Voyages where Id = @voyageId", con);
        getTicketVoyage.Parameters.AddWithValue("@voyageId", ticket.VoyageId);
        ticket.myVoyage = new Voyage();
        try
        {
          con.Open();
          reader = getTicketVoyage.ExecuteReader();

          reader.Read();
          ticket.myVoyage.Id = Convert.ToInt32(reader[0]);
          ticket.myVoyage.ShipId = Convert.ToInt32(reader[1]);
          ticket.myVoyage.Departure = Convert.ToDateTime(reader[2]);
          ticket.myVoyage.Arrival = Convert.ToDateTime(reader[3]);
          ticket.myVoyage.RoomsAvailable = Convert.ToInt32(reader[4]);
          ticket.myVoyage.TotalRooms = Convert.ToInt32(reader[5]);
          ticket.myVoyage.Destination = reader[6].ToString();
        }
        catch(Exception ex) { throw new Exception(ex.Message); }
        finally { con.Close(); }

        SqlCommand getVoyageShip = new SqlCommand("select * from cruiseShip where Id = @shipId", con);
        getVoyageShip.Parameters.AddWithValue("@shipId", ticket.ShipId);
        ticket.myVoyage.CruiseShip = new CruiseShip();

        try
        {
          con.Open();
          reader = getVoyageShip.ExecuteReader();

          reader.Read();
          ticket.myVoyage.CruiseShip.Id = Convert.ToInt32(reader[0]);
          ticket.myVoyage.CruiseShip.PortCity = reader[1].ToString();
          ticket.myVoyage.CruiseShip.PortState = reader[2].ToString();
          ticket.myVoyage.CruiseShip.ShipName = reader[3].ToString();
          ticket.myVoyage.CruiseShip.CruiseLine = reader[4].ToString();
          ticket.myVoyage.CruiseShip.AdultPrice = Convert.ToDecimal(reader[5]);
          ticket.myVoyage.CruiseShip.ChildPrice = Convert.ToDecimal(reader[6]);
          ticket.myVoyage.CruiseShip.RoomPrice = Convert.ToDecimal(reader[7]);
          ticket.myVoyage.CruiseShip.TripLength = Convert.ToInt32(reader[8]);
          ticket.myVoyage.CruiseShip.Img1 = reader[9].ToString();
          ticket.myVoyage.CruiseShip.Img2 = reader[10].ToString();
          ticket.myVoyage.CruiseShip.Img3 = reader[11].ToString();
          ticket.myVoyage.CruiseShip.Img4 = reader[12].ToString();

        }
        catch(Exception ex) { throw new Exception(ex.Message); }
        finally { con.Close(); }

        SqlCommand getShipItinerary = new SqlCommand("select * from Itinerary where shipId = @shipId",con);
        getShipItinerary.Parameters.AddWithValue("@shipId",ticket.myVoyage.CruiseShip.Id);
        ticket.myVoyage.CruiseShip.Itineraries = new List<Itinerary>();
        try
        {
          con.Open();
          reader = getShipItinerary.ExecuteReader();

          while(reader.Read())
          {
            Itinerary itinerary = new Itinerary();
            itinerary.ShipId = Convert.ToInt32(reader[0]);
            itinerary.Day = Convert.ToInt32(reader[1]);
            itinerary.City = reader[2].ToString();
            itinerary.StateCountry = reader[3].ToString();
            itinerary.PortTime = reader[4].ToString();
            ticket.myVoyage.CruiseShip.Itineraries.Add(itinerary);
          }
        }
        catch(Exception ex) { throw new Exception(ex.Message); }
        finally { con.Close(); }
      }

      return Ok(myTickets);

      
    }
  }
}
