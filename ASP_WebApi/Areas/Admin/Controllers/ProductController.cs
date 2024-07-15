using ASP_.Net_MVC_PROJECT.DATAACCESS.Data;
using ASP_.Net_MVC_PROJECT.DATAACCESS.Repository.IRepository;
using ASP_.Net_MVC_PROJECT.Models;
using ASP_.Net_MVC_PROJECT.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_WebApi.Areas.Admin.Controllers
{
    [Area("Admin")] //these tell our controller that it inside the Area and Admin side of the area
    public class ProductController : Controller
    {
        //On a normal we can initiate applicationDbConnection db = new applicationDbConnection() if at all we are not working with .Net core and we are using legacy.net application but in these case we would not
        private readonly IUinitOfWork _UnitOfWork; //whatever we get through our constructor will be assigned to our local variable using dependence injection
        public ProductController(IUinitOfWork uinitOfWork)
        {
            _UnitOfWork = uinitOfWork;
        }
        //the above constructor and local variable will allow to use our IActionResult method inside any other action method
        public IActionResult Index()
        {
            //Next we want to retrieve our Product with table and class and we don't need sql for that just entityframework is okay

            List<Product> objProductList = _UnitOfWork.Product.GetAll().ToList(); //meaning we are retrieving our data under DbSet  ApplicationDBConnection class
            
            return View(objProductList); //passing the category view to controller
        }
        //Note: if we are creating we might not have Id but updating require Id
        public IActionResult UpSert(int? id) //note: we change our create to UpSert//this method help with creation of new page or category once new category is cclick on our site
        {
            //how do retrieve list of product without any other model, we use Ienumerable container with help of SelectListItem
            //IEnumerable<SelectListItem> CategoryList = _UnitOfWork.Category.GetAll() //how do we retrieve and convert product from our database, we use EF Projection             
            //     .Select(u => new SelectListItem
            //     {
            //         //next we pass in property that needs to be populated
            //         Text = u.Name,
            //         Value = u.Id.ToString()

            //     };

            //ViewBag.CategoryList = CategoryList;
            //Next here we are trying the viewdata- which contain element of dicttionary collection
            //ViewData["CategoryList"] = CategoryList; //this is how value are assign to viewdata
            //Another method to vew our data creating seperate class to realize these
            ProductVM productVM = new()
            {
                //CategoryList = _UnitOfWork.Category.GetAll().Select(u => new SelectListItem//how do we retrieve and convert product from our database, we use EF Projection             
                 
                // {
                //     //next we pass in property that needs to be populated
                //     Text = u.Name,
                //     Value = u.Id.ToString()

                // }),
            Product = new Product(),

            };
            if(id ==null || id ==0)
            {
                //Create functionaity
                return View(productVM);
            }
            else
            {
                //Update functionality
                productVM.Product = _UnitOfWork.Product.Get(u => u.Id == id); //we use Get because we want to return only the product
                return View(productVM);
            }
          
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM) //this method help with Post of our create FORM page inside create.cshtml section 
        {
            if (ModelState.IsValid) //this basically check if the modestate(obj) isvalid then it will go to Product
            {
                _UnitOfWork.Product.Add(productVM.Product); //this line here is telling entity framework to add any input data we inputed to this category table on database but to save it we use _db.savechanges();
                _UnitOfWork.Save(); //this line tells database to create and save on our database
                TempData["success"] = "Product created succeessfully";
                return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to
            }
            else
            {

                //productVM.CategoryList = _UnitOfWork.Category.GetAll().Select(u => new SelectListItem//how do we retrieve and convert product from our database, we use EF Projection             

                //{
                //    //next we pass in property that needs to be populated
                //    Text = u.Name,
                //    Value = u.Id.ToString()

                //});
                return View(productVM);
            }
        }


        public IActionResult Edit(int? id) //this method help in editing etc and by adding int? null
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Next we need to retrive our edit from database using several method
            Product? productFromDb = _UnitOfWork.Product.Get(u => u.Id == id); //this method only work with primary key
            //Product? categoryFromDb1 = _db.Product.FirstOrDefault(u=>u.Id==id); //second method this can be modify in several ways 
            //Product? categoryFromDb2 = _db.Product.Where(u => u.Id == id).FirstOrDefault(); //third method but the second is more preferable
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj) //this method help with Post of our create FORM page inside create.cshtml section 
        {

            if (ModelState.IsValid) //this basically check if the modestate(obj) isvalid then it will go to Product
            {
                _UnitOfWork.Product.Update(obj);    /*Add(obj);*/ //this line here is telling entity framework to add any input data we inputed to this category table on database but to save it we use _db.savechanges();
                _UnitOfWork.Save(); //this line tells database to create and save on our database
                TempData["success"] = "Product updated succeessfully";
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
            Product? productFromDb = _UnitOfWork.Product.Get(u => u.Id == id); //this method only work with primary key
            //Product? categoryFromDb1 = _db.Product.FirstOrDefault(u=>u.Id==id); //second method this can be modify in several ways 
            //Product? categoryFromDb2 = _db.Product.Where(u => u.Id == id).FirstOrDefault(); //third method but the second is more preferable
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //this method help with Post of our create FORM page inside create.cshtml section 
        {
            Product? obj = _UnitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.Product.Remove(obj);
            _UnitOfWork.Save();
            TempData["success"] = "Product deleted succeessfully";
            return RedirectToAction("Index"); //redirectionToAction will help us redirect to the index or which action we need to

            //return View(); 
        }
    }
}
