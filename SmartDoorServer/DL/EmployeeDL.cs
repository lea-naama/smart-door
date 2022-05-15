using Entities;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using SmartDoorServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class EmployeeDL : IEmployeeDL
    {
        SmartDoorContext _smartDoorContext = new SmartDoorContext();
        public EmployeeDL(SmartDoorContext smartDoorContext)
        {
            _smartDoorContext = smartDoorContext;
        }

        public async Task<EmployeeDTO> GetEmployeeDetails(int id)
        {
            try
            {
                EmployeeDTO employee = await (from e in _smartDoorContext.Employees
                                      join d in _smartDoorContext.Departments
                                      on e.DepartmentId equals d.DepartmentId
                                      select new EmployeeDTO
                                      {
                                          Id = e.Id,
                                          Email = e.Email,
                                          FirstName = e.FirstName,
                                          LastName = e.LastName,
                                          Address = e.Address,
                                          Phone = e.Phone,
                                          Department =new DepartmentDTO
                                          {
                                              DepartmentId = d.DepartmentId,
                                              Description = d.Description, 
                                              ManagerId = d.ManagerId
                                          },
                                          EmployeeId = e.EmployeeId,
                                          Password = e.Password,
                                          DirectManagerId = e.DirectManagerId,                                          
                                      }
                    ).FirstOrDefaultAsync();
                Employee employee1 = await _smartDoorContext.Employees
               .Where(e => e.Id == id).FirstOrDefaultAsync();
                return employee;                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
