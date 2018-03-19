using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCore.Project.Authorization;
using AbpCore.Project.Controllers;
using AbpCore.Project.MultiTenancy;
using AbpCore.Project.Dto;
using AbpCore.Project.Web.Models.Common.Modals;

namespace AbpCore.Project.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : ProjectControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            //var output = await _tenantAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue }); // Paging not implemented yet
            return View();
        }

        public async Task<ActionResult> EditTenantModal(int tenantId)
        {
            var tenantDto = await _tenantAppService.Get(new EntityDto(tenantId));
            return View("_EditTenantModal", tenantDto);
        }

        public async Task<ActionResult> QueryPage(QueryPageBaseInput input)
        {
            var output = await _tenantAppService.GetAll(input); // Paging not implemented yet
            return Json(output);
        }

    }
}
