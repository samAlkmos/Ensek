using Ensek.DAL.Repositories.IRepositories;
using Ensek.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ensek.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly EnsekDbContext _ensekDbContext;
        public GenericRepository(EnsekDbContext ensekDbContext)
        {
            _ensekDbContext = ensekDbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntry = await _ensekDbContext.AddAsync(entity);
            await _ensekDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _ensekDbContext.AddRangeAsync(entity);
            await _ensekDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _ensekDbContext.Remove(entity);
            return await _ensekDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _ensekDbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _ensekDbContext.Set<TEntity>().ToListAsync() : _ensekDbContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _ensekDbContext.Update(entity);
            await _ensekDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _ensekDbContext.UpdateRange(entity);
            await _ensekDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
