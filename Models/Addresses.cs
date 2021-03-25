using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Buildings = new HashSet<Buildings>();
            Customers = new HashSet<Customers>();
        }

        public long Id { get; set; }
        public string TypeOfAddress { get; set; }
        public string Status { get; set; }
        public string Entity { get; set; }
        public string NumberAndStreet { get; set; }
        public string SuiteAndApartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }

        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
