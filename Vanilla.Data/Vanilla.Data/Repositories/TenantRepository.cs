using System;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public class TenantRepository : Repository<Tenant, VanillaContext>, ITenantRepository
    {
        private readonly VanillaContext _context;

        public TenantRepository(VanillaContext context) : base(context)
        {
            _context = context;
        }
    }
}

