using MultiShop.Cargo.Entity.Abstract;

using System.Linq.Expressions;

namespace MultiShop.Cargo.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity?> GetByIdAsync(string id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(string id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
