using System;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public class LegalEntityRepository : Repository<LegalEntity, VanillaContext>, ILegalEntityRepository
    {
        private readonly VanillaContext _context;

        public LegalEntityRepository(VanillaContext context) : base(context)
        {
            _context = context;
        }
    }
}
