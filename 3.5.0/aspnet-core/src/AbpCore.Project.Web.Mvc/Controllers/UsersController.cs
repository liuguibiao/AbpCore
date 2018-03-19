using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCore.Project.Authorization;
using AbpCore.Project.Controllers;
using AbpCore.Project.Users;
using AbpCore.Project.Web.Models.Users;
using AbpCore.Project.Dto;
using AbpCore.Project.Extend;
using Abp.UI;

namespace AbpCore.Project.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ProjectControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            //var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var permissions = (await _userAppService.GetAllPermissions()).Items;
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                //Users = users,
                Roles = roles,
                Permissions = permissions
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var permissions = (await _userAppService.GetAllPermissions()).Items;
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles,
                Permissions = permissions
            };
            return View("_EditUserModal", model);
        }

        public async Task<ActionResult> QueryPage(QueryPageBaseInput input)
        {
            var users = await _userAppService.GetAll(input); // Paging not implemented yet
            return Json(users);
        }
    }
}
