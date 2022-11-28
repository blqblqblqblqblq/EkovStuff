using Models.Requests;
using Models.Responses;
using Services.Interfaces;
using Services.Mapperts;
using Vanilla.Data.Repositories;

namespace Services
{
    public class MembershipGroupService : IMembershipGroupService
    {
        private readonly IMembershipGroupRepository _membershipGroupRepository;

        public MembershipGroupService(IMembershipGroupRepository membershipGroupRepository)
        {
            _membershipGroupRepository = membershipGroupRepository;
        }

        public async Task<MembershipGroupResponse> CreateMembershipGroup(CreateMembershipGroupRequest createMembershipGroupRequest)
        {
            var membershipGroup = await this._membershipGroupRepository.Add(createMembershipGroupRequest.ToMembershipGroup());
            return membershipGroup.ToCreateMembershipGroupResponse();
        }

        public async Task<MembershipGroupResponse> UpdateMembershipGroup(UpdateMembershipGroupRequest updateMembershipGroupRequest)
        {
            var membershipGroup = await this._membershipGroupRepository.Update(updateMembershipGroupRequest.ToMembershipGroup());
            return membershipGroup.ToCreateMembershipGroupResponse();
        }

        public async Task<MembershipGroupResponse> DeleteMembershipGroup(Guid id)
        {
            var membershipGroup = await this._membershipGroupRepository.Delete(id);
            return membershipGroup.ToCreateMembershipGroupResponse();
        }
    }
}
