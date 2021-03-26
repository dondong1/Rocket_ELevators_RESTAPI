using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Batteries = new HashSet<Batteries>();
            InterventionsAuthor = new HashSet<Interventions>();
            InterventionsEmployee = new HashSet<Interventions>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<Interventions> InterventionsAuthor { get; set; }
        public virtual ICollection<Interventions> InterventionsEmployee { get; set; }
    }
}
