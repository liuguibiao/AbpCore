using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCore.Project.Controllers;

namespace AbpCore.Project.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index_Top() {
            return View();
        }
    }
}
