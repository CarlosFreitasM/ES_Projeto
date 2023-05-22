using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.Models;


namespace Projeto_ESFase2.Controllers
{
    public class AuthController : Controller
    {
        private readonly ES2Context _context;

        public AuthController(ES2Context context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login()
        {
            
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register()
        {
            
        }
    }
}
