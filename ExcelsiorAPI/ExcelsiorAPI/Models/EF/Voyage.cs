using System;
using System.Collections.Generic;

namespace ExcelsiorAPI.Models.EF
{
    public partial class Voyage
    {

        public int Id { get; set; }
        public int? ShipId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }

        public CruiseShip? Ship { get; set; }

        public Itinerary? Itinerary { get; set; }
     
    }
}
