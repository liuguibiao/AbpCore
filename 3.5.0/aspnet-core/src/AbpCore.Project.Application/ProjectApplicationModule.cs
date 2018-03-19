using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCore.Project.Authorization;

namespace AbpCore.Project
{
    [DependsOn(
        typeof(ProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
