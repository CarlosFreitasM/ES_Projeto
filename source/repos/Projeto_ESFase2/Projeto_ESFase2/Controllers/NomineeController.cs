using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Controllers
{
    public class NomineeController : Controller
    {

        private readonly ES2Context _context;

        public NomineeController(ES2Context context)
        {
            _context = context;

        }
        // GET: NomineeController
        public ActionResult Index()
        {
            return View(_context.Nominees.ToList());
        }

        // GET: NomineeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NomineeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NomineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Nominee nominee)
        {
            var iterateNominee = await _context.Nominees.ToListAsync();

            if (ModelState.IsValid)
            {
                foreach (var item in iterateNominee)
                {
                    if (nominee.Name.ToLower() == item.Name.ToLower())
                    {
                        ViewData["Error"] = "Ja existe um nominee com este nome";
                        return View();
                    }
                }
                _context.Add(nominee);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Nominee");
            }
            ViewData["Error"] = "Algo correu errado";
            return View();
        }

        // GET: NomineeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NomineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NomineeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NomineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
