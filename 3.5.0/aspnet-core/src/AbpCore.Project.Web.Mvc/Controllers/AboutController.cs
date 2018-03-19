using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCore.Project.Controllers;

namespace AbpCore.Project.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
