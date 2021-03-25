using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Buildings = new HashSet<Buildings>();
        }

        public long Id { get; set; }
        public DateTime? CustomersCreationDate { get; set; }
        public string CompanyName { get; set; }
        public string FullNameOfCompanyContact { get; set; }
        public string CompanyContactPhone { get; set; }
        public string EmailOfCompanyContact { get; set; }
        public string CompanyDescription { get; set; }
        public string FullNameOfServiceTechnicalAuthority { get; set; }
        public string TechnicalAuthorityPhoneForService { get; set; }
        public string TechnicalManagerEmailForService { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
    }
}
