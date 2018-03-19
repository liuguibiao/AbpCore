using System.Collections.Generic;
using AbpCore.Project.Roles.Dto;
using AbpCore.Project.Users.Dto;

namespace AbpCore.Project.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
