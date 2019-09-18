using ImageGallery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        Task Create(T entity);

        void Update(T entity);

        void Delete(int id);

        T Find(Expression<Func<T, bool>> predicate);
    }
}
