using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    [Authorize]
    [Route("Booking/{action}")]
    public class BookingController : Controller
    {
        private readonly IEjendomService _ejendomService;
        private readonly string viewPath = "Views/Dashboard/Common/Booking";

        public BookingController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

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

        public async Task<ActionResult> Create(Guid id)
        {
            var model = new BookingOverviewViewModel();
            return View($"{viewPath}/Create.cshtml", model);
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
