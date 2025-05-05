using AutoMapper;
using BLL.Dtos.Employees;
using PL.Models.Employees;

namespace PL.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDto, EmployeesViewModel>();
            CreateMap<EmployeeDetailsDto, EmployeeDetailsViewModel>();
            CreateMap<CreationEmployeeViewModel, CreateEmployeeDto>();
            CreateMap<EmployeeDetailsDto, UpdationEmployeeViewModel>();
            CreateMap<UpdationEmployeeViewModel, UpdatedEmployeeDto>();
        }
    }
}
