using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDoorServer.Entities;
using BL;
using Profile = AutoMapper.Profile;
using DL;
using Entities.DTO;

namespace SmartDoorServer
{
    public class AutoMapper :Profile
    {
       public AutoMapper()
        {
            CreateMap<Employee, EmployeeDTO>();
            
            
          
            //CreateMap<Employee, EmployeeDTO>
        }
    }
}
