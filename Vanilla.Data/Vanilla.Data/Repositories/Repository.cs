using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vanilla.Data.DTOs;

namespace Vanilla.Data.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TContext : VanillaContext
    {
        private readonly TContext context;
        public Repository(TContext context)
        {
            this.context = context;
        }
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                await context.Set<TEntity>().AddAsync(entity);
                return entity;
            }
            catch (Exception x)
            {
                context.RollBack();
                throw;
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception x)
            {
                context.RollBack();
                throw;
            }
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);

            return entity;
        }

        public virtual async Task ReloadAsync(TEntity entity)
        {
            if (entity != null)
            {
                await context.Entry(entity).ReloadAsync();
            }
        }

        public async virtual Task<TEntity> Get(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<PagedList<TEntity>> GetAll(int pageNum, int pageSize = 10, string orderBy = "")
        {
            int skip = (pageNum - 1) * pageSize;

            if (skip < 0)
            {
                skip = 0;
            }


            var dbset = context.Set<TEntity>();

            IQueryable<TEntity> query = dbset;

            if (orderBy == "")
            {
                query = query.OrderBy(o => o.Id);
            }
            else
            {
                query = OrderByHelper.OrderBy(query, orderBy);
            }


            var totalCount = await query.CountAsync();

            var objects = await query
                                .Skip(skip)
                                .Take(pageSize)
                                .ToListAsync();



            var result = new PagedList<TEntity>()
            {
                Objects = objects,
                TotalCount = totalCount
            };

            return result;
        }

        public async virtual Task<int> CountAll()
        {
            return await context.Set<TEntity>().CountAsync();
        }

        public async virtual void AddRange(List<TEntity> entities)
        {
            try
            {
                await context.Set<TEntity>().AddRangeAsync(entities);

            }
            catch (Exception x)
            {
                context.RollBack();
                throw;
            }
        }

    }
}
