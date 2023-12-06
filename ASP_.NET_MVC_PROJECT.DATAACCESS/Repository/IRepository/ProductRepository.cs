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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBConnection _db;

        public ProductRepository(ApplicationDBConnection db) :base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);   
        }
    }
}
