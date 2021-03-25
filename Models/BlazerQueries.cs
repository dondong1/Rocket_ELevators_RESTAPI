using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class BlazerQueries
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Statement { get; set; }
        public string DataSource { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
