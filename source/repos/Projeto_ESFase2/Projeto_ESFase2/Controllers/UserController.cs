using Microsoft.AspNetCore.Mvc;

namespace Projeto_ESFase2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
