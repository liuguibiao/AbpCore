using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using AbpCore.Project.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbpCore.Project.Controllers
{
    public abstract class ProjectControllerBase : AbpController
    {
        protected ProjectControllerBase()
        {
            LocalizationSourceName = ProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected ActionResult Json(Tow tow)
        {
            return base.Json(tow.T());
        }
    }
}
