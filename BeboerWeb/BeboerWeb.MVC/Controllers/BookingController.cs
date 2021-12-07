using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IEjendomService _ejendomService;

        private readonly string viewPath = "Views/Dashboard/Common/Booking";

        public BookingController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            var models = new List<EjendomWithLokalerViewModel>();
            var dtos = await _ejendomService.GetEjendommeWithLokalerAsync();

            foreach (var dto in dtos)
            {
                var model = new EjendomWithLokalerViewModel();
                model.AddDataFromDTO(dto);
                models.Add(model);
            }

            return View($"{viewPath}/Index.cshtml", models);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
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

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
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
