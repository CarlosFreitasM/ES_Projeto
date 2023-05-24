using Microsoft.AspNetCore.Mvc;

namespace ES_Fase2.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
