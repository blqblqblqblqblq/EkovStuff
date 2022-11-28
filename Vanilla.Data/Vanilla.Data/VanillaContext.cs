using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vanilla.Data.Models;

namespace Vanilla.Data
{
    public class VanillaContext: DbContext, IVanillaContext
    {
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<LegalEntityAddress> LegalEntityAddresses { get; set; }
        public DbSet<LegalEntityEmail> LegalEntityEmails { get; set; }
        public DbSet<LegalEntityPhone> LegalEntityPhones { get; set; }
        public DbSet<MembershipGroup> MembershipGroups { get; set; }
        public DbSet<MembershipGroupMember> MembershipGroupMembers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        private string _connectionString;

        public VanillaContext()
        : base()
        {//This constructor is used for migrations only
            _connectionString = "server=127.0.0.1;database=Vanilla;user=vanilla;password=VanillaPass";
            //_connectionString = "";//PROD
            //_connectionString = "";//STAGE
        }

        public VanillaContext(DbContextOptions<VanillaContext> options)
            : base(options)
        {
            //used for unit testing Memory database
            //it is important that this is below the parameterless constructor because
            //the migration tool will fail
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null && _connectionString != "")
            {//This is used for migrations
                Console.WriteLine("connection string: " + _connectionString);
                Console.WriteLine("version: " + ServerVersion.AutoDetect(_connectionString));

                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString),
                 options => options.EnableRetryOnFailure())
                 .EnableSensitiveDataLogging();
            }
        }

        public void RollBack()
        {
            var changedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
