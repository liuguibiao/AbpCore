using Abp.Application.Navigation;
using Abp.Localization;
using AbpCore.Project.Authorization;

namespace AbpCore.Project.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            #region 权限首页
            //var Home = new MenuItemDefinition(PageNames.Home, L("HomePage"), url: "", icon: "home", requiresAuthentication: true);
            var Permissions = new MenuItemDefinition("Permissions", L("Permissions"), url: "", icon: "", requiresAuthentication: true);
            var Tenants = new MenuItemDefinition(PageNames.Tenants, L("Tenants"), url: "Tenants", icon: "business", requiredPermissionName: PermissionNames.Pages_Tenants);
            var Users = new MenuItemDefinition(PageNames.Users, L("Users"), url: "Users", icon: "people", requiredPermissionName: PermissionNames.Pages_Users);
            var Roles = new MenuItemDefinition(PageNames.Roles, L("Roles"), url: "Roles", icon: "local_offer", requiredPermissionName: PermissionNames.Pages_Roles);
            var Organization = new MenuItemDefinition(PageNames.Organization, L("Organization"), url: "Organization", icon: "local_offer", requiredPermissionName: PermissionNames.Pages_Organization);
            var About = new MenuItemDefinition(PageNames.About, L("About"), url: "About", icon: "info");
            Permissions.AddItem(Tenants);//租户
            Permissions.AddItem(Users);//用户
            Permissions.AddItem(Roles);//角色
            Permissions.AddItem(Organization);//机构
            Permissions.AddItem(About);
            context.Manager.MainMenu.AddItem(Permissions);//权限
            //context.Manager.MainMenu.AddItem(Home);//首页
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ProjectConsts.LocalizationSourceName);
        }
    }
}
