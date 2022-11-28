using Models.Requests;
using Models.Responses;

namespace Services.Interfaces
{
    public interface IMembershipGroupService
    {
        Task<MembershipGroupResponse> CreateMembershipGroup(CreateMembershipGroupRequest createMembershipGroupRequest);
        Task<MembershipGroupResponse> UpdateMembershipGroup(UpdateMembershipGroupRequest createMembershipGroupRequest);
        Task<MembershipGroupResponse> DeleteMembershipGroup(Guid id);
    }
}
