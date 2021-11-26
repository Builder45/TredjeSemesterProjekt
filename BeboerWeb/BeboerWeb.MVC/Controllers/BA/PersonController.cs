using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Http;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class PersonController : Controller
    {

        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: BrugerController
        public async Task<ActionResult> Index()
        {
            var model = await _personService.GetPersonAsync();
            return View("Views/Dashboard/BA/Perosn/Index.cshtml", model);
        }

        // GET: BrugerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrugerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrugerController/Create
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

        // GET: BrugerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrugerController/Edit/5
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

        // GET: BrugerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrugerController/Delete/5
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
