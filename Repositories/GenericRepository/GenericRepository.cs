using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Catalog.Interfaces.IGenericRepository;
using Catalog.Models;


namespace Catalog.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>()
                .Where(expression)
                .AsNoTracking();
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>()
                .AsNoTracking();
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> Delete(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null)
            {
                return obj;
            }
            _context.Set<TEntity>().Remove(obj);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var res = await _context.Set<TEntity>().ToListAsync();
            return res;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public Task<TEntity> GetByName(Func<TEntity, bool> name)
        {
            return Task.FromResult(_context.Set<TEntity>().AsNoTracking().Where(name).FirstOrDefault());
        }

        public Task<TEntity> Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return Task.FromResult(obj);
        }
    }
}
