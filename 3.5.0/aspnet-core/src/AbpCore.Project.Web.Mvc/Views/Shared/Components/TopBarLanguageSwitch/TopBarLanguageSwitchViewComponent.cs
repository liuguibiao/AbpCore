﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Abp.Localization;

namespace AbpCore.Project.Web.Views.Shared.Components.TopBarLanguageSwitch
{
    public class TopBarLanguageSwitchViewComponent : ProjectViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public TopBarLanguageSwitchViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public IViewComponentResult Invoke()
        {
            var model = new TopBarLanguageSwitchViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages().Where(l => !l.IsDisabled).ToList()
            };

            return View(model);
        }
    }
}
