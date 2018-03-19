using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCore.Project.Authorization.Accounts.Dto;

namespace AbpCore.Project.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
