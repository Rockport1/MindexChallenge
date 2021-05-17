using challenge.Models;
using challenge.resources;
using AutoMapper;

namespace challenge.Mapping
{
    public class ModelToResourceProfile : Profile
    {
		public ModelToResourceProfile()
		{
			CreateMap<Employee, EmployeeResource>();
			CreateMap<ReportingStructure, ReportingStructureResource>();
			CreateMap<Compensation, CompensationResource>();
		}
	}
}
