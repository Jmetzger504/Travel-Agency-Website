using System;
using System.Collections.Generic;

namespace ExcelsiorAPI.Models.EF
{
    public partial class Itinerary
    {
        public int? ShipId { get; set; }
        public int? Day { get; set; }
        public string? City { get; set; }
        public string? StateCountry { get; set; }
        public string? PortTime { get; set; }

    }
}
