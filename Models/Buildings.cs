using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Batteries = new HashSet<Batteries>();
            BuildingDetails = new HashSet<BuildingDetails>();
        }

        public long Id { get; set; }
        public string FullNameOfTheBuildingAdministrator { get; set; }
        public string EmailOfTheAdministratorOfTheBuilding { get; set; }
        public string PhoneNumberOfTheBuildingAdministrator { get; set; }
        public string FullNameOfTheTechnicalContactForTheBuilding { get; set; }
        public string TechnicalContactEmailForTheBuilding { get; set; }
        public string TechnicalContactPhoneForTheBuilding { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<BuildingDetails> BuildingDetails { get; set; }
    }
}
