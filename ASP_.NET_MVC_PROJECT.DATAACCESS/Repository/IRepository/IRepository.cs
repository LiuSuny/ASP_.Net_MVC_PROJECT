using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository
{
    //One thing to take note of when working with generic is that we didn't know what type it will be.
    public interface IRepository<T> where T :class
    {
        //T-GetAlll
        //Implementing the interface our repository as we using generic collection to implement it 

        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);   //we can use GetFirstOrDefault() or GetValue all are the same
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        //Note that we already have Update()in our CategoryController reason why it not necessary
        //Next we need to create new class which will be use to realize our interface


    }
}
