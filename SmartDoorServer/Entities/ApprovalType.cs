using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class ApprovalType
    {
        public ApprovalType()
        {
            ActionTypes = new HashSet<ActionType>();
        }

        public int ApprovalTypeId { get; set; }
        public string ApprovalType1 { get; set; }

        public virtual ICollection<ActionType> ActionTypes { get; set; }
    }
}
