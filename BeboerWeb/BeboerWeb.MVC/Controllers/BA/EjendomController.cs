using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class EjendomController : Controller
    {

        private readonly IEjendomService _ejendomService;

        public EjendomController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

         // GET: EjendomController
        public async Task<ActionResult> Index()
        {
            var model = await _ejendomService.GetEjendommeAsync();
            return View("Views/Dashboard/BA/Ejendom/Index.cshtml", model);
        }

        // GET: EjendomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EjendomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EjendomController/Create
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

        // GET: EjendomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EjendomController/Edit/5
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

        // GET: EjendomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EjendomController/Delete/5
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
