using ASP_WebApi.Data;
using ASP_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WebApi.Controllers
{
    public class CategoryController : Controller
    {
        //On a normal we can initiate applicationDbConnection db = new applicationDbConnection() if at all we are not working with .Net core and we are using legacy.net application but in these case we would not
        private readonly ApplicationDBConnection _db; //whatever we get through our constructor will be assigned to our local variable
        public CategoryController(ApplicationDBConnection db)
        {
            _db = db;
        }
        //the above constructor and local variable will allow to use our IActionResult method inside any other action method
        public IActionResult Index()
        {
            //Next we want to retrieve our Category with table and class and we don't need sql for that just entityframework is okay

          List<Category> objCategory =  _db.Category.ToList(); //meaning we are retrieving our data under DbSet  ApplicationDBConnection class
            return View(objCategory); //passing the category view to controller
        }
    }
}
