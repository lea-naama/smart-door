using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class UserCase
    {
        public UserCase()
        {
            UserCaseProflies = new HashSet<UserCaseProflie>();
        }

        public int UserCaseId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserCaseProflie> UserCaseProflies { get; set; }
    }
}
