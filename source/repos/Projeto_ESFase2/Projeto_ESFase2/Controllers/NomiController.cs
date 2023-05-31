using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Controllers
{
    public class NomiController : Controller
    {
        private readonly ES2Context _context;

        public NomiController(ES2Context context)
        {
            _context = context;
        }

        // GET: Nomi
        public ActionResult Index()
        {

            return View(_context.Nominees.ToList());
                          
        }

        // GET: Nomi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nominees == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominee == null)
            {
                return NotFound();
            }

            return View(nominee);
        }

        // GET: Nomi/Create
        public IActionResult Create()
        {
         
            return View();
        }

        // POST: Nomi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Nominee nominee)
        {
            var addingNominee = await _context.Nominees.ToListAsync();
          
            if (ModelState.IsValid)
            {
                foreach (var item in addingNominee)
                {
                    if (item.Name == nominee.Name)
                    {
                        ViewData["ErrorNomi"] = "This nominee name is already on the data base";
                        return View();
                    }
                }
                _context.Add(nominee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Nomi");
            }
            
            ViewData["Error"] = "Something went wrong!";
            return View();
        }

        // GET: Nomi/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Nominees == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominees.FindAsync(id);
            if (nominee == null)
            {
                return NotFound();
            }
            return View(nominee);
        }

        // POST: Nomi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Nominee nominee)
        {
            if (id != nominee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nominee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NomineeExists(nominee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nominee);
        }

        // GET: Nomi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nominees == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominee == null)
            {
                return NotFound();
            }

            return View(nominee);
        }

        // POST: Nomi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nominees == null)
            {
                return Problem("Entity set 'ES2Context.Nominees'  is null.");
            }
            var nominee = await _context.Nominees.FindAsync(id);
            if (nominee != null)
            {
                _context.Nominees.Remove(nominee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NomineeExists(int id)
        {
          return (_context.Nominees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
