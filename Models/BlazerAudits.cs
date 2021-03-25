using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class BlazerAudits
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? QueryId { get; set; }
        public string Statement { get; set; }
        public string DataSource { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
