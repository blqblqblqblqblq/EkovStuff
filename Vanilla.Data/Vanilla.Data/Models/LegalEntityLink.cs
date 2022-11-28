using System;
namespace Vanilla.Data.Models
{
    public class LegalEntityLink : IEntity
    {
        public Guid Id { get; set; }
        public Guid LegalEntity1 { get; set; }
        public Guid LegalEntity2 { get; set; }
        public RelationshipType RelationshipType { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }

    public enum RelationshipType
    {
        IsMarriedTo=1,
        LivesWith,
        IsParentOf,
        IsChildOf,
        IsSiblingOf,
        WorksFor
    }
}
