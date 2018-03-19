using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCore.Project.Sessions.Dto;

namespace AbpCore.Project.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
