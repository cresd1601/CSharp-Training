using System.Linq.Expressions;

using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filterPredicate,
            Expression<Func<TEntity, object>> orderPredicate,
            bool orderByDescending,
            int pageNumber,
            int pageSize
        );

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<int> CountAsync();
    }
}


