using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class Profile
    {
        public Profile()
        {
            EmployeeProfiles = new HashSet<EmployeeProfile>();
            UserCaseProflies = new HashSet<UserCaseProflie>();
        }

        public int ProfileId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual ICollection<UserCaseProflie> UserCaseProflies { get; set; }
    }
}
