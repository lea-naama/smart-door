using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SubEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DirectManagerId { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLasttName { get; set; }
    }
}
