using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCore.Project.Organizations.Dto
{
    public class OrganizationDto : EntityDto<long>
    {
        public string Code { get; set; }

        public long? ParentId { get; set; }

        public string DisplayName { get; set; }
    }
}
