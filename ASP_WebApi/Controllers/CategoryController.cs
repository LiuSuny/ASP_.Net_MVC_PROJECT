using Microsoft.AspNetCore.Mvc;

namespace ASP_WebApi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
