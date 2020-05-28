using System.Threading.Tasks;
using Abp.Application.Services;
using SPAVUE.Authorization.Accounts.Dto;

namespace SPAVUE.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
