using System;
using System.Collections.Generic;

namespace ExcelsiorAPI.Models.EF
{
    public partial class CruiseShip
    {
        public CruiseShip()
        {
            CruiseTickets = new List<CruiseTicket>();
            Voyages = new List<Voyage>();
            Itineraries = new List<Itinerary>();
        }

        public int Id { get; set; }
        public int? AvailableRooms { get; set; }
        public int? TotalRooms { get; set; }
        public string? PortCity { get; set; }
        public string? PortState { get; set; }
        public string? ShipName { get; set; }
        public string? CruiseLine { get; set; }
        public string? Destination { get; set; }
        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
        public decimal? RoomPrice { get; set; }
        public int? TripLength { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? Img4 { get; set; }

        public List<CruiseTicket> CruiseTickets { get; set; }
        public List<Voyage> Voyages { get; set; }
        public List<Itinerary> Itineraries {get; set;}
    }
}
