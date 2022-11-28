using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanilla.Data.DTOs;

namespace Vanilla.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<PagedList<T>> GetAll(int pageNum, int pageSize, string orderBy = "");
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void AddRange(List<T> entities);
        Task<T> Delete(Guid id);
        Task ReloadAsync(T entity);
        Task<int> CountAll();
    }
}
