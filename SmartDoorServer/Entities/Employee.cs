using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Actions = new HashSet<Action>();
            EmployeeProfiles = new HashSet<EmployeeProfile>();
            InverseDirectManager = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
        public int? DirectManagerId { get; set; }
        public int? DepartmentId { get; set; }
        public double? StandardDailyHours { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee DirectManager { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual ICollection<Employee> InverseDirectManager { get; set; }
    }
}
