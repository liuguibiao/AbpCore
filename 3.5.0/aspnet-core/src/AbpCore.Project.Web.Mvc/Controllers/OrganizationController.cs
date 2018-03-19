using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpCore.Project.Controllers;
using AbpCore.Project.Extend;
using AbpCore.Project.Organizations;
using AbpCore.Project.Organizations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AbpCore.Project.Web.Mvc.Controllers
{
    public class OrganizationController : ProjectControllerBase
    {
        private readonly IOrganizationAppService _iOrganizationAppService;
        public OrganizationController(IOrganizationAppService iOrganizationAppService)
        {
            _iOrganizationAppService = iOrganizationAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(long id)
        {
            var result = await _iOrganizationAppService.Get(new EntityDto<long> { Id = id });
            return View("_EditModal", result);
        }
    }
}