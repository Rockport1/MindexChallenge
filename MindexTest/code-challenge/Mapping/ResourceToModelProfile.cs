using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using challenge.Models;
using challenge.resources;

namespace challenge.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //CreateMap<EmployeeResource, Employee>();
            CreateMap<SaveCompensationResource, Compensation>();
        }
    }
}
