using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class ActionType
    {
        public ActionType()
        {
            Actions = new HashSet<Action>();
        }

        public int ActionTypeId { get; set; }
        public string ActionType1 { get; set; }
        public bool? IsPresent { get; set; }
        public int? ApprovalTypeId { get; set; }

        public virtual ApprovalType ApprovalType { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}
