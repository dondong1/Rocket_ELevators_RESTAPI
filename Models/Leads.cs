using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Leads
    {
        public long Id { get; set; }
        public string FullNameOfContact { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DepartmentInChargeOfElevators { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? customer_id { get; set; }
    }
}
