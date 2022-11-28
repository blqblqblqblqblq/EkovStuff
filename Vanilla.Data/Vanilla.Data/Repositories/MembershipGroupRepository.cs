using System;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public class MembershipGroupRepository : Repository<MembershipGroup, VanillaContext>, IMembershipGroupRepository
    {
        private readonly VanillaContext _context;

        public MembershipGroupRepository(VanillaContext context) : base(context)
        {
            _context = context;
        }
    }
}
