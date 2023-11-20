using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ASP_.Net_MVC_PROJECT.DATAACCESS.Data;
using ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASP_.Net_MVC_PROJECT.DATAACCESS.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Adding dependence injection

        private readonly ApplicationDBConnection _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDBConnection db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //db.Category = dbSet;

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault(); ////almost the same thing we did in CategoryController categoryFromDb2 = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
