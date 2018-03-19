using Abp.Dependency;
using Abp.Localization;
using Abp.Localization.Sources;
using System.Collections.Generic;

namespace AbpCore.Project.Extend
{
    public class M
    {
        private readonly static ILocalizationContext _iLocalizationContext;
        static M()
        {
            towDict = new Dictionary<Tow, string>();
            towDict.Add(Tow.DeleteSuccess, "DeleteSuccess");
            towDict.Add(Tow.CreateSuccess, "CreateSuccess");
            towDict.Add(Tow.EditSuccess, "EditSuccess");
            towDict.Add(Tow.SaveSuccess, "SaveSuccess");
            towDict.Add(Tow.About, "About");
            towDict.Add(Tow.DataAnomaly, "DataAnomaly");
            _iLocalizationContext = IocManager.Instance.Resolve<ILocalizationContext>();
        }

        public static string L(string name)
        {
            return new LocalizableString(name, ProjectConsts.LocalizationSourceName).Localize(_iLocalizationContext);
        }
        public string Mes { get; set; }

        public static M Mesg(Tow tow)
        {
            return new M()
            {
                Mes = L(towDict[tow])
            };
        }
        public static string MesgStr(Tow tow)
        {
            return L(towDict[tow]);
        }

        private static Dictionary<Tow, string> towDict;
    }
    public enum Tow
    {
        DeleteSuccess,
        CreateSuccess,
        EditSuccess,
        SaveSuccess,
        /// <summary>
        /// 关于我们
        /// </summary>
        About,
        /// <summary>
        /// 数据异常 (Data anomaly)
        /// </summary>
        DataAnomaly
    }
}
