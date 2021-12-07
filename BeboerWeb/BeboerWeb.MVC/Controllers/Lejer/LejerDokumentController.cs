using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    public class LejerDokumentController : Controller
    {
        private readonly string viewPath = "Views/Dashboard/Lejer/Dokumenter";

        // GET: DokumentController
        public ActionResult Index()
        {
            return View($"{viewPath}/Index.cshtml");
        }

        // GET: DokumentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DokumentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DokumentController/Create
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

        // GET: DokumentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DokumentController/Edit/5
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

        // GET: DokumentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DokumentController/Delete/5
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
