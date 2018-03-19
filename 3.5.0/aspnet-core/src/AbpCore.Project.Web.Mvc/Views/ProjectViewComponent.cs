using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpCore.Project.Web.Views
{
    public abstract class ProjectViewComponent : AbpViewComponent
    {
        protected ProjectViewComponent()
        {
            LocalizationSourceName = ProjectConsts.LocalizationSourceName;
        }
    }
}
