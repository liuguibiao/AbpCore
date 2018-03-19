using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCore.Project.Roles.Dto;
using AbpCore.Project.Users.Dto;

namespace AbpCore.Project.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
