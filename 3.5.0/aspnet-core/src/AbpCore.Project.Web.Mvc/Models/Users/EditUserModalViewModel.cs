using System.Collections.Generic;
using System.Linq;
using AbpCore.Project.Roles.Dto;
using AbpCore.Project.Users.Dto;

namespace AbpCore.Project.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }

        public bool HasPermission(PermissionDto permission)
        {
            return Permissions != null && User.PermissionsT.Any(p => p.Name == permission.Name);
        }
    }
}
