using System;
using System.Collections.Generic;

namespace ExcelsiorAPI.Models.EF
{
    public partial class Customer
    {
        public Customer()
        {
            CruiseTickets = new List<CruiseTicket>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public decimal? Balance { get; set; }

        public List<CruiseTicket> CruiseTickets { get; set; }
    }
}
