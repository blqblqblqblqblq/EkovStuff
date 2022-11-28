using Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace API.Examples
{
    public class CreateMembershipGroupRequestExample : IExamplesProvider<CreateMembershipGroupRequest>
    {
        public CreateMembershipGroupRequest GetExamples()
        {
            return new CreateMembershipGroupRequest()
            {
               Description= "description",
               FeeAmount = 100,
               FeeType = "NoFeeRequired",
               GroupName = "GroupName",
               TenantId = Guid.NewGuid()
            };
        }
    }
}
