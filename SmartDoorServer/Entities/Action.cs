using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class Action
    {
        public int ActionId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public int? StatusId { get; set; }
        public int? ActionTypeId { get; set; }
        public int? EnteringTypeId { get; set; }

        [JsonIgnore]
        public virtual ActionType ActionType { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual EnteringType EnteringType { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
    }
}
