
using ASP_.Net_MVC_PROJECT.DATAACCESS.Data;
using ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository;
using ASP_.Net_MVC_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WebApi.Areas.Admin.Controllers
{
    [Area("Admin")]//these tell our controller that it inside the Area and Admin side of the area
    public class CategoryController : Controller
    {
        //On a normal we can initiate applicationDbConnection db = new applicationDbConnection() if at all we are not working with .Net core and we are using legacy.net application but in these case we would not
        private readonly IUinitOfWork _UnitOfWork; //whatever we get through our constructor will be assigned to our local variable using dependence injection
        public CategoryController(IUinitOfWork uinitOfWork)
        {
            _UnitOfWork = uinitOfWork;
        }
        //the above constructor and local variable will allow to use our IActionResult method inside any other action method
        public IActionResult Index()
        {
            //Next we want to retrieve our Category with table and class and we don't need sql for that just entityframework is okay

            List<Category> objCategory = _UnitOfWork.Category.GetAll().ToList(); //meaning we are retrieving our data under DbSet  ApplicationDBConnection class
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
                ModelState.AddModelError("name", "The DisplayOrders cannot exactly match the name");
            }

            if (ModelState.IsValid) //this basically check if the modestate(obj) isvalid then it will go to Category
            {
                _UnitOfWork.Category.Add(obj); //this line here is telling entity framework to add any input data we inputed to this category table on database but to save it we use _db.savechanges();
                _UnitOfWork.Save(); //this line tells database to create and save on our database
                TempData["success"] = "Category created succeessfully";
                return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to
            }
            return View();
        }


        public IActionResult Edit(int? id) //this method help in editing etc and by adding int? null
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Next we need to retrive our edit from database using several method
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id); //this method only work with primary key
            //Category? categoryFromDb1 = _db.Category.FirstOrDefault(u=>u.Id==id); //second method this can be modify in several ways 
            //Category? categoryFromDb2 = _db.Category.Where(u => u.Id == id).FirstOrDefault(); //third method but the second is more preferable
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj) //this method help with Post of our create FORM page inside create.cshtml section 
        {

            if (ModelState.IsValid) //this basically check if the modestate(obj) isvalid then it will go to Category
            {
                _UnitOfWork.Category.Update(obj); //this line here is telling entity framework to update any input data we inputed to this category table on database but to save it we use _db.savechanges();
                _UnitOfWork.Save(); //this line tells database to create and save on our database
                TempData["success"] = "Category updated succeessfully";
                return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to
            }
            return View();
        }


        //DELETE OPTION 
        public IActionResult Delete(int? id) //this method help in editing etc and by adding int? null
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Next we need to retrive our edit from database using several method
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id); //this method only work with primary key
            //Category? categoryFromDb1 = _db.Category.FirstOrDefault(u=>u.Id==id); //second method this can be modify in several ways 
            //Category? categoryFromDb2 = _db.Category.Where(u => u.Id == id).FirstOrDefault(); //third method but the second is more preferable
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //this method help with Post of our create FORM page inside create.cshtml section 
        {
            Category? obj = _UnitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.Category.Remove(obj);
            _UnitOfWork.Save();
            TempData["success"] = "Category deleted succeessfully";
            return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to

            //return View(); 
        }
    }
}
