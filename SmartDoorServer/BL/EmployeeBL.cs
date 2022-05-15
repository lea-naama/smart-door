using AutoMapper;
using DL;
using Entities.DTO;
using SmartDoorServer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeDL _employeeDL;
        IMapper _mapper;
        public EmployeeBL(IEmployeeDL employeeDL, IMapper mapper)
        {
            _employeeDL = employeeDL;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeeDetails(int id)
        {
            try
            {
                EmployeeDTO employee = await _employeeDL.GetEmployeeDetails(id);
                //EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
