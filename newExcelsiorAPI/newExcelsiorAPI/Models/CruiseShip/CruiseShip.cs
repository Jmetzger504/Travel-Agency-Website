using newExcelsiorAPI.Models;

namespace newExcelsiorAPI.Models
 
{
  public class CruiseShip
  {
    public CruiseShip()
    {
      Itineraries = new List<Itinerary>();
    }

    public int? Id { get; set; }
    public string? PortCity { get; set; }
    public string? PortState { get; set; }
    public string? ShipName { get; set; }
    public string? CruiseLine { get; set; }
    public decimal? AdultPrice { get; set; }
    public decimal? ChildPrice { get; set; }
    public decimal? RoomPrice { get; set; }
    public int? TripLength { get; set; }
    public string? Img1 { get; set; }
    public string? Img2 { get; set; }
    public string? Img3 { get; set; }
    public string? Img4 { get; set; }

    
    public List<Itinerary> Itineraries { get; set; }
  }
}
