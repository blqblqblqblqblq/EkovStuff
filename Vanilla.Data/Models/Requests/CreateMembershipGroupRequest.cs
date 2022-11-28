using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class CreateMembershipGroupRequest
    {
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string FeeType { get; set; }
        public decimal FeeAmount { get; set; }
        public Guid TenantId { get; set; }
    }
}
