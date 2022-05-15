using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class UserCaseProflie
    {
        public int UserCaseProfileId { get; set; }
        public int? UserCaseId { get; set; }
        public int? ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual UserCase UserCase { get; set; }
    }
}
