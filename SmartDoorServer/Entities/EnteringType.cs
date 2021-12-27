using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class EnteringType
    {
        public EnteringType()
        {
            Actions = new HashSet<Action>();
        }

        public int EnteringTypeId { get; set; }
        public string EntringType { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
