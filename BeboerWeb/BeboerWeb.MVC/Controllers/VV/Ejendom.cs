using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.VV.Ejendom
{
    public class Ejendom : Controller
    {
        // GET: Ejendom
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ejendom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejendom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejendom/Create
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

        // GET: Ejendom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejendom/Edit/5
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

        // GET: Ejendom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejendom/Delete/5
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
