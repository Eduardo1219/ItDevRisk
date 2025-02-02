using Domain.Base.Entity;
using Domain.Base.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Base
{
    public abstract class BaseRepository<B> : IBaseRepository<B> where B : BaseEntity
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(List<B> entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.AddRange(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<B>> GetAll()
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<B> GetByIdAsync(Guid id)
        {
            var dbSet = _context.Set<B>();
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public virtual async Task<B> GetOneAsync(Expression<Func<B, bool>> search)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<List<B>> FindAsync(Expression<Func<B, bool>> search)
        {
            return await _context.Set<B>()
                .AsNoTracking()
                .Where(search)
                .ToListAsync();
        }


        public virtual async Task RemoveAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveManyAsync(List<B> entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.RemoveRange(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveByIdAsync(Guid id)
        {
            var dbSet = _context.Set<B>();
            var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return;

            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(B entity)
        {
            var dbSet = _context.Set<B>();
            dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateManyAsync(List<B> entities)
        {
            var dbSet = _context.Set<B>();
            dbSet.UpdateRange(entities);

            await _context.SaveChangesAsync();
        }
    }
}
