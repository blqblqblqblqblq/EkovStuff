using System;
using System.Threading.Tasks;
using Vanilla.Data.Repositories;

namespace Vanilla.Data.UnitsOfWork
{
    public class VanillaUnitOfWork: IVanillaUnitOfWork
    {
        VanillaContext _context;

        public ILegalEntityRepository LegalEntities { get; }
        public IMembershipGroupRepository MembershipGroups { get; }
        public ITenantRepository Tenants { get; }

        public VanillaUnitOfWork(VanillaContext context)
        {
            _context = context;

            LegalEntities = new LegalEntityRepository(_context);
            MembershipGroups = new MembershipGroupRepository(_context);
            Tenants = new TenantRepository(_context);
        }

        

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
