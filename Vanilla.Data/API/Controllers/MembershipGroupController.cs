using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipGroupController : ControllerBase
    {
        private readonly IMembershipGroupService _membershipGroupServicec;

        public MembershipGroupController(IMembershipGroupService membershipGroupServicec)
        {
            _membershipGroupServicec = membershipGroupServicec;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembershipGroup(CreateMembershipGroupRequest createMembershipGroupRequest)
        {
            var result = await this._membershipGroupServicec.CreateMembershipGroup(createMembershipGroupRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMembershipGroup(UpdateMembershipGroupRequest updateMembershipGroupRequest)
        {
            var result = await this._membershipGroupServicec.UpdateMembershipGroup(updateMembershipGroupRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteMembershipGroup(Guid id)
        {
            var rsult = await this._membershipGroupServicec.DeleteMembershipGroup(id);
            return Ok(rsult);
        }
    }
}
