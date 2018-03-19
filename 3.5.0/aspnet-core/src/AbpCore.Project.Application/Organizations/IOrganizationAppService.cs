using Abp.Application.Services;
using AbpCore.Project.Dto;
using AbpCore.Project.Organizations.Dto;
using System.Threading.Tasks;

namespace AbpCore.Project.Organizations
{
    public interface IOrganizationAppService : IAsyncCrudAppService<OrganizationDto, long, QueryPageBaseInput, CreateOrUpdateOrganizationDto, CreateOrUpdateOrganizationDto>
    {
        Task CreateAsync(CreateOrUpdateOrganizationDto input);
    }
}
