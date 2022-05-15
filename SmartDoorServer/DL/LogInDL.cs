using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartDoorServer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class LogInDL : ILogInDL
    {
        SmartDoorContext _smartDoorContext;
        IConfiguration _configuration;
        public LogInDL(SmartDoorContext smartDoorContext, IConfiguration  configuration )
        {
            _smartDoorContext = smartDoorContext;
            _configuration = configuration;
        }

        public async Task<LogInResponse> GetUser(string userName, string password)
        {
            try
            {
                User user = await _smartDoorContext.Employees
                .Where(e => e.Email == userName && e.Password == password)
                .Select(e => new User
                {
                    Email = e.Email,
                    Password = e.Password,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Id = e.Id
                })
                .FirstOrDefaultAsync();

                List<SubEmployee> employeeList = new List<SubEmployee>();
                if(user!= null)
                {
                    employeeList = GetEmployeeList(user.Id);
                }

                LogInResponse response = new LogInResponse()
                {
                    User = user,
                    EmployeeList = employeeList
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private List<SubEmployee> GetEmployeeList(int employeeId)
        {
            try
            {
                List<SubEmployee> employeeList = new List<SubEmployee>();
                SqlDataReader reader;
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("SmartDoor")))
                using (SqlCommand cmd = new SqlCommand("P_GET_EMPLOYEE_LIST", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMP_ID", employeeId);                    
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SubEmployee employee = new SubEmployee();
                        if (!reader.IsDBNull(0))
                            employee.EmployeeId = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            employee.FirstName = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                            employee.LastName = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            employee.DirectManagerId = reader.GetInt32(3);
                        if (!reader.IsDBNull(4))
                            employee.ManagerFirstName = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                            employee.ManagerLasttName = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                            employee.Department = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                            employee.DepartmentId = reader.GetInt32(7);

                        employeeList.Add(employee);
                    }
                    cn.Close();
                }
                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
