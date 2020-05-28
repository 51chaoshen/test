using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPAVUE.Configuration;

namespace SPAVUE.Web.Host.Startup
{
    [DependsOn(
       typeof(SPAVUEWebCoreModule))]
    public class SPAVUEWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SPAVUEWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SPAVUEWebHostModule).GetAssembly());
        }
    }
}
