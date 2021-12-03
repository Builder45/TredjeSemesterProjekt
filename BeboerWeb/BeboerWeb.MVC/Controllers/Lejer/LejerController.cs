using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    public class LejerController : Controller
    {
        // GET: LejerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LejerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LejerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejerController/Create
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

        // GET: LejerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejerController/Edit/5
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

        // GET: LejerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejerController/Delete/5
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
