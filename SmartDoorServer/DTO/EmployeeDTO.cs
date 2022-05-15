using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {

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
    }
}
