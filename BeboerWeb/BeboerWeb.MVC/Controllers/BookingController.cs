using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
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
        private readonly IBookingService _bookingService;
        private readonly IPersonService _personService;
        private readonly string viewPath = "Views/Dashboard/Common/Booking";

        public BookingController(IEjendomService ejendomService, IBookingService bookingService, IPersonService personService)
        {
            _ejendomService = ejendomService;
            _bookingService = bookingService;
            _personService = personService;
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
            var brugerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = await _personService.GetPersonByBrugerAsync(Guid.Parse(brugerId));

            var model = new BookingOverviewViewModel();
            model.Booking.LokaleId = id;
            model.Booking.PersonId = person.Id;
            var dtos = await _bookingService.GetBookingerByLokaleAsync(model.Booking.LokaleId, model.SearchDate);
            foreach (var dto in dtos)
            {
                var booking = new BookingViewModel();
                booking.AddDataFromDTO(dto);
                model.ExistingBookinger.Add(booking);
            }
            return View($"{viewPath}/Create.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingOverviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = new BookingDTO()
                {
                    BookingPeriodeStart = model.Booking.BookingPeriodeStart,
                    BookingPeriodeSlut = model.Booking.BookingPeriodeSlut,
                    LokaleId = model.Booking.LokaleId,
                    PersonId = model.Booking.PersonId
                };
                await _bookingService.CreateBookingAsync(booking);
                return RedirectToAction("Index");
            }

            return View($"{viewPath}/Create.cshtml");
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

        public async Task<ActionResult> Delete(Guid id)
        {
            var brugerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = await _personService.GetPersonByBrugerAsync(Guid.Parse(brugerId));

            var model = new BookingOverviewViewModel();
            model.Booking.LokaleId = id;
            model.Booking.PersonId = person.Id;
            var dtos = await _bookingService.GetBookingerByLokaleAsync(model.Booking.LokaleId, model.SearchDate);
            foreach (var dto in dtos)
            {
                var booking = new BookingViewModel();
                booking.AddDataFromDTO(dto);
                model.ExistingBookinger.Remove(booking);
            }
            return View($"{viewPath}/Delete.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(BookingOverviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = new BookingDTO()
                {
                    BookingPeriodeStart = model.Booking.BookingPeriodeStart,
                    BookingPeriodeSlut = model.Booking.BookingPeriodeSlut,
                    LokaleId = model.Booking.LokaleId,
                    PersonId = model.Booking.PersonId
                };
                await _bookingService.DeleteBookingAsync(model.Booking.Id);
                return RedirectToAction("Index");
            }

            return View($"{viewPath}/Delete.cshtml");
        }
    }
}
