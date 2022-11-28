using System;
using System.Collections.Generic;

namespace Vanilla.Data.Models
{
    //A Legal Entity is a representation of a Person, a Company or an Organisation
    public class LegalEntity : IEntity
    {
        public Guid Id { get; set; }
        public string NamePrefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string CompanyNumber { get; set; }
        public string VatNunmber { get; set; }
        public string VoNumber { get; set; }
        public string JobTitle { get; set; }
        public LegalEntityType LegalEntityType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string Gender { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        public List<LegalEntityAddress> Addresses { get; set; }
        public List<LegalEntityEmail> EmailAddresses { get; set; }
        public List<LegalEntityPhone> PhoneNumbers { get; set; }

        public List<LegalEntityLink> LinkedLegalEntities { get; set; }
        public List<MembershipGroup> MembershipGroups { get; set; }

    }

    public enum LegalEntityType
    {
        Person = 1,
        Company = 2,
        VoluntaryOrganisation=3
    }
}
