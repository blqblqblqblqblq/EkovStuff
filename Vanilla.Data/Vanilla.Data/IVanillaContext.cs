using System;
using Microsoft.EntityFrameworkCore;
using Vanilla.Data.Models;

namespace Vanilla.Data
{
    public interface IVanillaContext
    {
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<LegalEntityAddress> LegalEntityAddresses { get; set; }
        public DbSet<LegalEntityEmail> LegalEntityEmails { get; set; }
        public DbSet<LegalEntityPhone> LegalEntityPhones { get; set; }
        public DbSet<MembershipGroup> MembershipGroups { get; set; }
        public DbSet<MembershipGroupMember> MembershipGroupMembers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public void RollBack();
    }
}
