using Abp.Organizations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCore.Project.Organizations.Dto
{
    public class OrganizationMapProfile : Profile
    {
        public OrganizationMapProfile()
        {
            CreateMap<OrganizationDto, OrganizationUnit>();
        }
    }
}
