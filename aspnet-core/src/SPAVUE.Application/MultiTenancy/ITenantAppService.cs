using Abp.Application.Services;
using SPAVUE.MultiTenancy.Dto;

namespace SPAVUE.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

