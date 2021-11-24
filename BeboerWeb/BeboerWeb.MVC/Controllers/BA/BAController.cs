using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class BAController : Controller
    {
        // GET: BAController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BAController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BAController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BAController/Create
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

        // GET: BAController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BAController/Edit/5
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

        // GET: BAController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BAController/Delete/5
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
