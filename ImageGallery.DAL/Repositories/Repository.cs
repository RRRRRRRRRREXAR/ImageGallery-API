using ImageGallery.DAL.DB;
using ImageGallery.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private GalleryContext db;
        DbSet<T> _dbSet;
        public Repository(GalleryContext context)
        {
            this.db = context;
            _dbSet = context.Set<T>();
        }
        public async Task Create(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void Delete(int id)
        {
            T item = _dbSet.Find(id);
            if (item != null)
            {
               _dbSet.Remove(item);
            }
        }

        public  Task<List<T>> Find(Expression<Func<T,bool>> predicate)
        {
            return _dbSet.Where(predicate).ToListAsync(); 
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
