using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCore.Project.MultiTenancy.Dto;

namespace AbpCore.Project.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
