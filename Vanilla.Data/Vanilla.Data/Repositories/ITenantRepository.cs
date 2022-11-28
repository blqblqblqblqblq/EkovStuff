using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanilla.Data.DTOs;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public interface ITenantRepository
    {
        Task<PagedList<Tenant>> GetAll(int pageNum, int pageSize, string orderBy = "");
        Task<Tenant> Get(Guid id);
        Task<Tenant> Add(Tenant entity);
        void AddRange(List<Tenant> entities);
        Task<Tenant> Delete(Guid id);
        Task ReloadAsync(Tenant entity);
        Task<int> CountAll();
    }
}

