using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string ProductLine { get; set; }
        public string InstallationFee { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
        public string BuildingType { get; set; }
        public int? NumOfFloors { get; set; }
        public int? NumOfApartments { get; set; }
        public int? NumOfBasements { get; set; }
        public int? NumOfParkingSpots { get; set; }
        public int? NumOfDistinctBusinesses { get; set; }
        public int? NumOfElevatorCages { get; set; }
        public int? NumOfOccupantsPerFloor { get; set; }
        public int? NumOfActivityHoursPerDay { get; set; }
        public int? RequiredColumns { get; set; }
        public int? RequiredShafts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
