using System;
using System.Collections.Generic;

namespace ExcelsiorAPI.Models.EF
{
    public partial class CruiseTicket
    {
        public int Id { get; set; }
        public int? VoyageId { get; set; }
        public int? CustId { get; set; }
        public int? ShipId { get; set; }
        public int? Rooms { get; set; }
        public int? ChildGuests { get; set; }
        public int? AdultGuests { get; set; }
        public decimal? TotalCost { get; set; }

        public Customer? Cust { get; set; }
        public CruiseShip? Ship { get; set; }
        public Voyage? Voyage { get; set; }
    }
}
