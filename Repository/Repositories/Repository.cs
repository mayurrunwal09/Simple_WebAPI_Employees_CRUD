using Domain.BaseEntityClass;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MainDbContext _context;
        private readonly DbSet<T> _entities;
        public async Task<bool> Delete(T entity)
        {
            _entities.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _entities.FirstOrDefaultAsync(match);
        }

        public async Task<ICollection<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await _entities.Where(match).ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public T GetLast()
        {
            return _entities.LastOrDefault();
        }

        public async Task<bool> Insert(T entity)
        {
            if (entity == null)
            {
                _entities.Add(entity);
                var result = await _context.SaveChangesAsync();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
            /*_entities.Add(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;*/
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
