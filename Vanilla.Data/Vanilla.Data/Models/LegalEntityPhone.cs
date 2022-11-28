using System;
namespace Vanilla.Data.Models
{
    public class LegalEntityPhone: IEntity
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Label { get; set; }
        public Guid LegalEntityId { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
