using System;
using System.Collections.Generic;

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

        public virtual ActionType ActionType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EnteringType EnteringType { get; set; }
        public virtual Status Status { get; set; }
    }
}
