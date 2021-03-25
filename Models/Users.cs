using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Users
    {
        public Users()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordSentAt { get; set; }
        public DateTime? RememberCreatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte? SuperadminRole { get; set; }
        public byte? EmployeeRole { get; set; }
        public byte? UserRole { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
