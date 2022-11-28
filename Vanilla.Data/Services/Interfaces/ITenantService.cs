using Models.Requests;
using Models.Responses;

namespace Services.Interfaces
{
    public interface ITenantService
    {
        Task<CreateTenantResponse> CreateTenant(CreateTenantRequest createTenantRequest);
    }
}
