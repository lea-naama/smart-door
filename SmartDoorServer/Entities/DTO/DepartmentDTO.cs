using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public int? ManagerId { get; set; }
    }
}
