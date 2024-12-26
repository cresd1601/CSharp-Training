using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using Shopee.Infrastructure.Contexts;
using Shopee.Infrastructure.Entities;

namespace Shopee.Infrastructure.Repositories.Implement
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ShopeeDbContext _shopeeDBContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ShopeeDbContext context)
        {
            _shopeeDBContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
            await _shopeeDBContext.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _shopeeDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = _dbSet.Remove(entity).Entity;
            await _shopeeDBContext.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filterPredicate,
            Expression<Func<TEntity, object>> orderPredicate,
            bool orderByDescending,
            int pageNumber,
            int pageSize)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            // Apply filtering
            if (filterPredicate != null)
            {
                query = query.Where(filterPredicate);
            }

            // Apply ordering
            if (orderPredicate != null)
            {
                query = orderByDescending ? query.OrderByDescending(orderPredicate) : query.OrderBy(orderPredicate);
            }

            // Enable AsNoTracking for performance boost on read-only operations
            query = query.AsNoTracking();

            // Apply pagination
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _dbSet.Where(predicate).FirstOrDefaultAsync();

            return entity;
        }


        public async Task<int> CountAsync()
        {
            var totalCount = await _dbSet.CountAsync();

            return totalCount;
        }
    }
}