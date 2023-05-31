using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NuGet.Packaging.Signing;
using Projeto_ESFase2.Data;
using Projeto_ESFase2.DTO;
using Projeto_ESFase2.Models;
using Projeto_ESFase2.Services;
using System.Linq;

namespace Projeto_ESFase2.Controllers
{
    public class CompetitionController : Controller, ICompetitionObservable
    {
        private readonly ES2Context _context;
        private CompetitionFuntions _competitionFuntions;
        private Iterator _iterator;
        private UserServices _userServices;
        private List<ICompetitionObserver> _observers;


        public CompetitionController(ES2Context context, CompetitionFuntions competitionFuntions, Iterator iterator, UserServices userServices)
        {
            _context = context;
            _competitionFuntions = competitionFuntions;
            _iterator = iterator;
            _observers = new List<ICompetitionObserver>();
            _userServices = userServices;

        }

        public void RegisterObserver(ICompetitionObserver observer)
        { 
            _observers.Add(observer);
        }

        public void UnregisterObserver(ICompetitionObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
        // GET: CompetitionController
        public ActionResult Index()
        {
           
            return View(_context.Competitions.ToList());

        }


        // GET: CompetitionController/AddNominee
        public async Task<ActionResult> AddNominee(int Id)
        { 
            var nomIds = new List<Nominee>();
        
            var competition = _context.Competitions.Include(c => c.CompetitionNominees).ThenInclude(cn => cn.Nominee).FirstOrDefault(c => c.Id == Id);
            
            var availableNominee = await _context.Nominees.ToListAsync();

            var compNom = competition.CompetitionNominees.Where(cn => cn.CompetitionId == Id);

            //Iterator
            foreach (var item in compNom)
            {
                var NomComp = _context.Nominees.FirstOrDefault(n => n.Id == item.NomineeId);
                nomIds.Add(NomComp);
            }

            var trueAvailableNominees = availableNominee.Except(nomIds).ToList();

            var viewModel = new AddNomineeViewModel
            {
                CompetitionId = competition.Id,

                CompetitionName = competition.Name,

                CompetitionCategory = competition.Category,
                
                AvailableNominee = trueAvailableNominees
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
                        NomineeId = selectedNominee.Id,
                        numberOfVotes = 0
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
                    if (competition.Name == item.Name)
                    {
                        ViewData["Error"] = "A competition with this name already exists";
                        return View();
                    }
             
                }
                _context.Add(competition);
                
                await _context.SaveChangesAsync();

                NotifyObservers("Competition has started!");

                return RedirectToAction("Index", "Competition");
            }
            ViewData["Error"] = "Algo correu errado";
            return View(_context.Competitions.ToList());
        }

        public async Task<ActionResult> ViewCompetition(int Id)
        {
            var nomIds = new List<Nominee>();
            var competition = await _context.Competitions.Include(cn => cn.CompetitionNominees).FirstOrDefaultAsync(c => c.Id == Id);

            var compNom = competition.CompetitionNominees.Where(cn => cn.CompetitionId == Id);

            var availableNominee = await _context.Nominees.ToListAsync();

            //Iterator
            foreach (var item in compNom)
            {
               var NomComp = _context.Nominees.FirstOrDefault(n => n.Id == item.NomineeId);
               nomIds.Add(NomComp);
            }

            var viewModel = new CompetitionViewModel
            {
                
                CompetitionId = competition.Id,
                CompetitionName = competition.Name,
                AvailableCompNom = nomIds,

            };
            return View(viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> VoteNominee([FromForm] CompetitionViewModel viewModel)
        {
            var competition = _context.Competitions.Include(c => c.CompetitionNominees)
                                                .FirstOrDefault(c => c.Id == viewModel.CompetitionId);
            var userVoted = _context.Competitions.Include(c => c.CompetitionUsers)
                                                .FirstOrDefault(c => c.Id == viewModel.CompetitionId);

            if (competition == null)
            {
                return NotFound();
            }

            if (userVoted == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && userVoted.CompetitionUsers.Find(u => u.UserId == UsersServices.userId) == null)
            {
                _competitionFuntions.incrementCompetitionNomineeNumberVotes(viewModel, competition);
                _context.SaveChanges();

                if (userVoted != null)
                {
                    var competitionUser = new CompetitionUser
                    {
                        CompetitionId = userVoted.Id,
                        UserId = UsersServices.userId,
                    };

                    userVoted.CompetitionUsers.Add(competitionUser);
                    _context.SaveChanges();
                }
                competition.NumberVotes++;
                _context.SaveChanges();

                return RedirectToAction("Index", "Competition"); // Redirect to the desired action and controller
            }
            ViewData["Error"] = "You already voted on this competition!";
            return View();
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

        public async Task<ActionResult> Details(int Id)
        {
            try
            {
                var nomIds = new List<Nominee>();
                var compNomVotes = new List<CompetitionNominee>();
                var competition = await _context.Competitions.Include(c => c.CompetitionNominees)
                                                             .ThenInclude(cn => cn.Nominee).FirstOrDefaultAsync(c => c.Id == Id);
                var compNom = competition.CompetitionNominees.Where(cn => cn.CompetitionId == Id);

                foreach (var item in compNom)
                {
                    var NomComp = _context.Nominees.FirstOrDefault(n => n.Id == item.NomineeId);
                    nomIds.Add(NomComp);
                }

                foreach (var item in nomIds)
                {
                    var NomComp = competition.CompetitionNominees.FirstOrDefault(n => n.NomineeId == item.Id);
                    compNomVotes.Add(NomComp);
                }

                var viewModel = new CompetitionResultViewModel
                {

                    CompetitionName = competition.Name,
                    TotalVotes = competition.NumberVotes,
                    AvailableCompNom = nomIds,
                    NumberOfVotesPer = compNomVotes

                };

                return View(viewModel);
            }
            catch (Exception ex) { return NotFound(); }
        }
    }
}
