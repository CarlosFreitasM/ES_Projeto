using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_ESFase2.Controllers
{
    public class NomineeController : Controller
    {
        // GET: NomineeController
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(IFormCollection collection)
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
