using System;
namespace Vanilla.Data.Models
{
    public class LegalEntityAddress : IEntity
    {
        public Guid Id { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public Guid LegalEntityId { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
