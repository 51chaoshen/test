using System.Threading.Tasks;
using Abp.Application.Services;
using SPAVUE.Sessions.Dto;

namespace SPAVUE.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
