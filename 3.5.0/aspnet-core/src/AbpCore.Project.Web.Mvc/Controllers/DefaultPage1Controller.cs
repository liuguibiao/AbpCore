using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AbpCore.Project.Web.Mvc.Controllers
{
    public class DefaultPage1Controller : AbpController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}