using Microsoft.AspNetCore.Antiforgery;
using AbpCore.Project.Controllers;

namespace AbpCore.Project.Web.Host.Controllers
{
    public class AntiForgeryController : ProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
