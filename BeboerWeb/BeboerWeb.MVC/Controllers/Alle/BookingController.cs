using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Alle
{
    [Authorize]
    [Route("Booking/{action}")]
    public class BookingController : Controller
    {
        private readonly IEjendomService _ejendomService;
        private readonly IBookingService _bookingService;
        private readonly IPersonService _personService;
        private readonly ILokaleService _lokaleService;
        private readonly string viewPath = "Views/Dashboard/Alle/Booking";

        public BookingController(IEjendomService ejendomService, IBookingService bookingService, IPersonService personService, ILokaleService lokaleService)
        {
            _ejendomService = ejendomService;
            _bookingService = bookingService;
            _personService = personService;
            _lokaleService = lokaleService;
        }

        public async Task<ActionResult> Index()
        {
            var models = new List<EjendomWithLokalerViewModel>();
            var dtos = await _ejendomService.GetEjendommeWithLokalerAsync();
            var dtosInOrder = dtos.OrderBy(e => e.Postnr).ThenBy(e => e.Adresse);
            foreach (var dto in dtosInOrder)
            {
                if (dto.Lokaler.Count > 0)
                {
                    var model = new EjendomWithLokalerViewModel();
                    model.AddDataFromDTO(dto);
                    models.Add(model);
                }
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

            var lokaleDto = await _lokaleService.GetLokaleAsync(id);
            var lokaleModel = new LokaleViewModel();
            lokaleModel.AddDataFromDto(lokaleDto);
            model.Booking.Lokale = lokaleModel;

            var currentDate = DateTime.Now;
            model.SearchMonth = currentDate.Month;
            model.SearchYear = currentDate.Year;

            var dtos = await _bookingService.GetBookingerByLokaleAndSearchDateAsync(model.Booking.LokaleId, currentDate);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateOverview(BookingOverviewViewModel model)
        {
            var searchDate = new DateTime(model.SearchYear, model.SearchMonth, 1);
            var dtos = await _bookingService.GetBookingerByLokaleAndSearchDateAsync(model.Booking.LokaleId, searchDate);
            foreach (var dto in dtos)
            {
                var booking = new BookingViewModel();
                booking.AddDataFromDTO(dto);
                model.ExistingBookinger.Add(booking);
            }

            var lokaleDto = await _lokaleService.GetLokaleAsync(model.Booking.LokaleId);
            var lokaleModel = new LokaleViewModel();
            lokaleModel.AddDataFromDto(lokaleDto);
            model.Booking.Lokale = lokaleModel;

            return View($"{viewPath}/Create.cshtml", model);
        }

        public async Task<ActionResult> MineBookinger()
        {
            var brugerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var person = await _personService.GetPersonByBrugerAsync(Guid.Parse(brugerId));

            var model = new MineBookingerViewModel();
            model.Booking.PersonId = person.Id;
            var dtos = await _bookingService.GetBookingerByBrugerAsync(model.Booking.PersonId);
            foreach (var dto in dtos)
            {
                var booking = new BookingViewModel();
                booking.AddDataFromDTO(dto);
                model.Bookinger.Add(booking);
            }
            return View($"{viewPath}/MineBookinger.cshtml", model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(MineBookingerViewModel model)
        {
            await _bookingService.DeleteBookingAsync(model.Booking.Id);
            return RedirectToAction("MineBookinger");
        }
    }
}
