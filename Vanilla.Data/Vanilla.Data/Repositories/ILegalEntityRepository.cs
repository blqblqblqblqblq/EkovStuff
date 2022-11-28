using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanilla.Data.DTOs;
using Vanilla.Data.Models;

namespace Vanilla.Data.Repositories
{
    public interface ILegalEntityRepository
    {
        Task<PagedList<LegalEntity>> GetAll(int pageNum, int pageSize, string orderBy = "");
        Task<LegalEntity> Get(Guid id);
        Task<LegalEntity> Add(LegalEntity entity);
        void AddRange(List<LegalEntity> entities);
        Task<LegalEntity> Delete(Guid id);
        Task ReloadAsync(LegalEntity entity);
        Task<int> CountAll();
    }
}
