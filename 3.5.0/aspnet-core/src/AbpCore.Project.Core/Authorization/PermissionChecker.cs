using Abp.Authorization;
using AbpCore.Project.Authorization.Roles;
using AbpCore.Project.Authorization.Users;

namespace AbpCore.Project.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, Users.User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
