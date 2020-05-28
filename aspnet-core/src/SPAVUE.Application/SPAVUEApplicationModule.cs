using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPAVUE.Authorization;

namespace SPAVUE
{
    [DependsOn(
        typeof(SPAVUECoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SPAVUEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SPAVUEAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SPAVUEApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
