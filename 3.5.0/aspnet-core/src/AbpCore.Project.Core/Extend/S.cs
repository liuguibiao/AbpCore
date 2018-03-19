using System;
using System.Collections.Generic;
using System.Text;
using static AbpCore.Project.Extend.M;

namespace AbpCore.Project.Extend
{
    public static class S
    {
        public static M T(this Tow tow) {
            return Mesg(tow);
        }
        public static string TL(this Tow tow)
        {
            return MesgStr(tow);
        }
    }
}
