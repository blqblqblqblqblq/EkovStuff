namespace Models.Responses
{
    public class MembershipGroupResponse
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string FeeType { get; set; }
        public decimal FeeAmount { get; set; }
        public Guid TenantId { get; set; }
    }
}
