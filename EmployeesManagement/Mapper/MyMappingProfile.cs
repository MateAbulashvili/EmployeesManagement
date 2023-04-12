using AutoMapper;
using EmployeesManagement.DAL.DTO;
using EmployeesManagement.Models;
using System.Collections.Generic;
using System.Threading;

namespace EmployeesManagement.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeDTO>();
        }
    }
}
