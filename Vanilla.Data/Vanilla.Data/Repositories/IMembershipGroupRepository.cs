using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanilla.Data.DTOs;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public interface IMembershipGroupRepository
    {
        Task<PagedList<MembershipGroup>> GetAll(int pageNum, int pageSize, string orderBy = "");
        Task<MembershipGroup> Get(Guid id);
        Task<MembershipGroup> Add(MembershipGroup entity);
        Task<MembershipGroup> Update(MembershipGroup entity);
        void AddRange(List<MembershipGroup> entities);
        Task<MembershipGroup> Delete(Guid id);
        Task ReloadAsync(MembershipGroup entity);
        Task<int> CountAll();
    }
}
