using Microsoft.EntityFrameworkCore;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Abstract;
using MultiShop.Order.Persistance.Context;

using System.Linq.Expressions;

namespace MultiShop.Order.Persistance.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
            where TEntity : BaseEntity,new()
    {
        protected OrderContext Context { get; }

        public GenericRepository(OrderContext context)
        {
            Context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter is null ?
                await Context.Set<TEntity>().ToListAsync() :
                await Context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity?> GetByIdAsync(string id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
