using System;
namespace Vanilla.Data.Models
{
    public class MembershipGroupMember : IEntity
    {
        public Guid Id { get; set; }
        public Guid MembershipGroupId { get; set; }
        public Guid LegalEntityId { get; set; }
        public DateTime MemberFrom { get; set; }
        public DateTime MemberTo { get; set; }
        public string Role { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
