using System;
using System.Threading.Tasks;
using Vanilla.Data.Repositories;

namespace Vanilla.Data.UnitsOfWork
{
    public interface IVanillaUnitOfWork
    {
        public ILegalEntityRepository LegalEntities { get; }
        public IMembershipGroupRepository MembershipGroups { get; }
        public ITenantRepository Tenants { get; }

        public Task<int> SaveChangesAsync();
    }
}
