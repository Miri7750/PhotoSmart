using Microsoft.EntityFrameworkCore;
using PhotoSmart.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbSet<T> _dbSet;

        public Repository(PhotoSmartContext context)
        {
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
           var res= await _dbSet.AddAsync(entity);
            return res.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var val =await GetByIdAsync(id);
            if (val != null)
            {
                _dbSet.Remove(val);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
          var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            await UpdateAsync(entity);
        }
        
    }
}
