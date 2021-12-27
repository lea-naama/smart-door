using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class Status
    {
        public Status()
        {
            Actions = new HashSet<Action>();
        }

        public int StatusId { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
