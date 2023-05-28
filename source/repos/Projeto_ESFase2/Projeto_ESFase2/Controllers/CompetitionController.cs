using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.Models;
using Projeto_ESFase2.Services;
using System.Linq;

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

        // GET: CompetitionController/AddNominee
        public async Task<ActionResult> AddNominee(int Id)
        {
            var competition = _context.Competitions.Include(c => c.CompetitionNominees).ThenInclude(cn => cn.Nominee).FirstOrDefault(c => c.Id == Id);
            
            var availableNominee = await _context.Nominees.ToListAsync();

            var viewModel = new AddNomineeViewModel
            {
                CompetitionId = competition.Id,
                CompetitionName = competition.Name,
                
                AvailableNominee = availableNominee
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNominee([FromForm] AddNomineeViewModel viewModel)
        {
            var competitionee = _context.Competitions.Include(c => c.CompetitionNominees)
                                                .FirstOrDefault(c => c.Id == viewModel.CompetitionId);

            if (competitionee == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var selectedNominee = _context.Nominees.Find(viewModel.SelectedNomineeIds);

                if (selectedNominee != null)
                {
                    var competitionNominee = new CompetitionNominee
                    {
                        CompetitionId = competitionee.Id,
                        NomineeId = selectedNominee.Id
                    };

                    competitionee.CompetitionNominees.Add(competitionNominee);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Competition"); // Redirect to the desired action and controller
            }

            viewModel.AvailableNominee = _context.Nominees.ToList();
            return View();
        }
    

    // GET: CompetitionController/AddNominee
    public ActionResult Create()
        {
            

            return View(_context.Competitions.ToList());
        }

        // POST: CompetitionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Competition competition)
        {

            var iterateCompetition = await _context.Competitions.ToListAsync();

            if (ModelState.IsValid)
            {
                foreach (var item in iterateCompetition)
                {
                    if (competition.Name == item.Name || competition.Category == item.Category )
                    {
                        ViewData["Error"] = "Ja existe uma competição com este nome ou categoria";
                        return View();
                    }

                     var competitions = new List<Competition>
                        { 
                            new Competition { Name = item.Name
                            , Category = item.Category
                            , NumberVotes = item.NumberVotes
                            , ClosingTime = item.ClosingTime
                            , StartingTime = item.StartingTime
                            , CompetitionUsers = item.CompetitionUsers
                            , CompetitionNominees = new List<CompetitionNominee>()},
                        };

                    
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
            List<Nominee> items = _context.Nominees.ToList();

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
