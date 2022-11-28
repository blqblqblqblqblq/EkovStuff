using System;
namespace Vanilla.Data.Models
{
    public class MembershipGroup : IEntity
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public MembershipFeeType FeeType { get; set; }
        public decimal FeeAmount { get; set; }

        public Guid TenantId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }

    public enum MembershipFeeType
    {
        NoFeeRequired,
        AnnualFee,
        MonthlyFee
    }
         
}
