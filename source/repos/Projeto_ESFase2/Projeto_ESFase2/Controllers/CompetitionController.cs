using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.Models;
using Projeto_ESFase2.Services;

namespace Projeto_ESFase2.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ES2Context _context;

        public CompetitionController(ES2Context context)
        {
            _context = context;

        }
        // GET: CompetitionController
        public ActionResult Index()
        {

            
            return View(_context.Competitions.ToList());
          
        }

        // GET: CompetitionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompetitionController/Create
        public ActionResult Create()
        {

            List<Nominee> nominees = new List<Nominee>();
            var listNominee = _context.Nominee.ToList();
            foreach (var nominee in listNominee)
            {
                nominees.Add(nominee);
            }

            ViewBag.nominee = nominees;

            return View();
        }

        // POST: CompetitionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Competition competition)
        {

            var iterateCompetition = await _context.Competitions.ToListAsync();
            var iterateNominee = competition.Nominee;

            if (ModelState.IsValid)
            {
                foreach (var item in iterateCompetition)
                {
                    if (competition.Name == item.Name || competition.Category == item.Category )
                    {
                        ViewData["Error"] = "Ja existe uma competição com este nome ou categoria";
                        return View();
                    }
                }
                _context.Add(competition);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Competition");
            }
            ViewData["Error"] = "Algo correu errado";
            return View(_context.Competitions.ToList());
        }

        // GET: CompetitionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompetitionController/Edit/5
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

        // GET: CompetitionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: CompetitionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deete(int id, IFormCollection collection)
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

        public List<GroupedNominee> Showgroup()
        {
            List<Nominee> items = _context.Nominee.ToList();

            var groupedItems = items.GroupBy(x => x.Type)
                                    .Select(g => new GroupedNominee
                                    {
                                        NomineeType = g.Key,   
                                        Items = g.ToList()
                                    })
                                    .ToList();
            return groupedItems;
        }
    }
}
