using Models.Requests;
using Models.Responses;
using Services.Interfaces;
using Services.Mapperts;
using Vanilla.Data.Repositories;

namespace Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ILegalEntityRepository _legalEntityRepository;

        public TenantService(ITenantRepository tenantRepository, ILegalEntityRepository legalEntityRepository)
        {
            _tenantRepository = tenantRepository;
            _legalEntityRepository = legalEntityRepository;
        }

        public async Task<CreateTenantResponse> CreateTenant(CreateTenantRequest createTenantRequest)
        {
            var tenant = await this._tenantRepository.Add(createTenantRequest.ToTenantEntity());

            var legalEntityForCreate = createTenantRequest.ToLegalEntity(tenant.Id);

            var legalEntity = await this._legalEntityRepository.Add(legalEntityForCreate);

            return new CreateTenantResponse
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Address1 = legalEntity.Addresses.First().Line1,
                Address2 = legalEntity.Addresses.First().Line2,
                Country = legalEntity.Addresses.First().Country,
                Locality = legalEntity.Addresses.First().Locality,
                PostCode = legalEntity.Addresses.First().PostCode,
                Email = legalEntity.EmailAddresses.First().Email,
                Phone = legalEntity.PhoneNumbers.First().Phone,
                OrganisationType = legalEntity.LegalEntityType.ToString()
            };
        }
    }
}
