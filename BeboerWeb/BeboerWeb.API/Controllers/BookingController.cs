using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Application.UseCases.BookingUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICreateBookingUseCase _createBookingUseCase;
        private readonly IGetBookingUseCase _getBookingUseCase;
        //private readonly IUpdateBookingUseCase _updateBookingUseCase;

        public BookingController(IGetBookingUseCase getBookingUseCase, ICreateBookingUseCase createBookingUseCase)//, IUpdateBookingUseCase updateBookingUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _getBookingUseCase = getBookingUseCase;
            //_updateBookingUseCase = updateBookingUseCase;
        }

        [HttpGet]
        public IEnumerable<string> GetBookinger()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("ByLokale/{lokaleId}/{searchDate}")]
        public IEnumerable<BookingDTO> GetBookingerByLokale(Guid lokaleId, DateTime searchDate)
        {
            var model = _getBookingUseCase.GetAllBookingerByLokaleBySearchDate(new GetBookingRequest
                {LokaleId = lokaleId, SearchDate = searchDate});
            var dto = new List<BookingDTO>();

            model.ForEach(a=>dto.Add(new BookingDTO
            {
                Id = a.Id,
                BookingPeriodeStart = a.BookingPeriodeStart,
                BookingPeriodeSlut = a.BookingPeriodeSlut
            }));
            return dto;
        }

        // POST api/<Booking>
        [HttpPost]
        public void PostBooking([FromBody] BookingDTO dto)
        {
            _createBookingUseCase.CreateBooking(new CreateBookingRequest
                (dto.BookingPeriodeStart, dto.BookingPeriodeSlut, dto.PersonId, dto.LokaleId));
        }

        // GET api/<Booking>/5
        [HttpGet("{id}")]
        public string GetBooking(int id)
        {
            return "value";
        }

        // PUT api/<Booking>/5
        [HttpPut("{id}")]
        public void PutBooking(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteBooking(int id)
        {
        }
    }
}
