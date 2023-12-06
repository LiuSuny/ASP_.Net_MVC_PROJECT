using ASP_.Net_MVC_PROJECT.DATAACCESS.Data;
using ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository;
using ASP_.Net_MVC_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP_.Net_MVC_PROJECT.DATAACCESS.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private readonly ApplicationDBConnection _db;

        public CategoryRepository(ApplicationDBConnection db) :base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Category.Update(obj);   
        }
    }
}
