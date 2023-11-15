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

        public IActionResult Create() //this method help with creation of new page or category once new category is cclick on our site
        {
          
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Category obj) //this method help with Post of our create FORM page inside create.cshtml section 
        {
            if (obj.Name == obj.DisplayOrders.ToString())
            {
                //AddModelError(key, string) key being our name and normal text display option
                ModelState.AddModelError("Name", "The DisplayOrders cannot exactly match the Name");
            }
            if (ModelState.IsValid) //this basically check if the modestate(obj) isvalid then it will go to Category
            {
                _db.Category.Add(obj); //this line here is telling entity framework to add any input data we inputed to this category table on database but to save it we use _db.savechanges();
                _db.SaveChanges(); //this line tells database to create and save on our database
                return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to
            }
            return View();
        }
    }
}
