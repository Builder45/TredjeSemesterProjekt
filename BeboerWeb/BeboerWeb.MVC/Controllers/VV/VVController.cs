using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.VV
{
    public class VVController : Controller
    {
        // GET: VVController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VVController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VVController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VVController/Create
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

        // GET: VVController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VVController/Edit/5
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

        // GET: VVController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VVController/Delete/5
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
