using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.VV.Lejemål
{
    public class Lejemål : Controller
    {
        // GET: Lejemål
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lejemål/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lejemål/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lejemål/Create
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

        // GET: Lejemål/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lejemål/Edit/5
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

        // GET: Lejemål/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lejemål/Delete/5
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
