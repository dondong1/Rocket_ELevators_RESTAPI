using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class BlazerChecks
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public long? QueryId { get; set; }
        public string State { get; set; }
        public string Schedule { get; set; }
        public string Emails { get; set; }
        public string SlackChannels { get; set; }
        public string CheckType { get; set; }
        public string Message { get; set; }
        public DateTime? LastRunAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
