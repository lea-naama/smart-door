using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class EmployeeProfile
    {
        public int EmployeeProfileId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProfileId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
