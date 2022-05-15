using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class LogInResponse
    {
        public User User { get; set; }
        public List<SubEmployee> EmployeeList { get; set; }
    }
}
