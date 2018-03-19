using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCore.Project.MultiTenancy;

namespace AbpCore.Project.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
