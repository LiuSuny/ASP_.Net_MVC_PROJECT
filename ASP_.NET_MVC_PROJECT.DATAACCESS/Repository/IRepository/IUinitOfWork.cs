using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository
{
    public interface IUinitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        //initialize our global method like save or update etc

        void Save();
    }
}
