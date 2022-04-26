namespace newExcelsiorAPI.Models
{
  public class CruiseTicket
  { 

    public int? Id { get; set; }
    public int? VoyageId { get; set; }
    public int? CustId { get; set; }
    public int? ShipId { get; set; }
    public int? Rooms { get; set; }
    public int? ChildGuests { get; set; }
    public int? AdultGuests { get; set; }
    public decimal? TotalCost { get; set; }

    public Voyage? myVoyage { get; set; }
  }
}
