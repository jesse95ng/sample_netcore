using AutoMapper;
using sample_netcore.Models.Dto;
using sample_netcore.Models.Entities;

namespace sample_netcore.Domain.Profiles.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Mapping profile Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
