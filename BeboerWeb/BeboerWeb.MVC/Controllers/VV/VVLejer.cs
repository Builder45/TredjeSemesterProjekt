using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.VV.Lejer
{
    public class VVLejer : Controller
    {
        // GET: Lejer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lejer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lejer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lejer/Create
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

        // GET: Lejer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lejer/Edit/5
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

        // GET: Lejer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lejer/Delete/5
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
