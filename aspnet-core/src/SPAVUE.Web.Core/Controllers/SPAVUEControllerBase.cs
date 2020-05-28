using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SPAVUE.Controllers
{
    public abstract class SPAVUEControllerBase: AbpController
    {
        protected SPAVUEControllerBase()
        {
            LocalizationSourceName = SPAVUEConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
