using Abp.Application.Navigation;
namespace AbpCore.Project.Web.Views.Home.Components.TopBarNav
{
    public class TopBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }

    }
}
