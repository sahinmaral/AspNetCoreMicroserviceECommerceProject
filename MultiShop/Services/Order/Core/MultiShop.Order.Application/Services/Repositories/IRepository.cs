using MultiShop.Order.Domain.Entities.Abstract;

using System.Linq.Expressions;

namespace MultiShop.Order.Application.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity,new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity?> GetByIdAsync(string id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
