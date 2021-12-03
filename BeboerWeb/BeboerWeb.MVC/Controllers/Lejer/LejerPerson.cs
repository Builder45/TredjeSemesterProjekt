using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    public class LejerPerson : Controller
    {
        // GET: LejerPerson
        public ActionResult Index()
        {
            return View();
        }

        // GET: LejerPerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LejerPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejerPerson/Create
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

        // GET: LejerPerson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejerPerson/Edit/5
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

        // GET: LejerPerson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejerPerson/Delete/5
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
