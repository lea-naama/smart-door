﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDoorServer.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public int? ManagerId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
