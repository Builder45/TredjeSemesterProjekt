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
        private readonly IDeleteBookingUseCase _deleteBookingUseCase;
        //private readonly IUpdateBookingUseCase _updateBookingUseCase;

        public BookingController(IGetBookingUseCase getBookingUseCase, ICreateBookingUseCase createBookingUseCase, IDeleteBookingUseCase deleteBookingUseCase)//, IUpdateBookingUseCase updateBookingUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _getBookingUseCase = getBookingUseCase;
            _deleteBookingUseCase = deleteBookingUseCase;
            //_updateBookingUseCase = updateBookingUseCase;
        }

        [HttpGet("ByLokale/{lokaleId}")]
        public IEnumerable<BookingDTO> GetBookingerByLokale(Guid lokaleId)
        {
            var model = _getBookingUseCase.GetBookingerByLokale(new GetBookingRequest
                {LokaleId = lokaleId });
            var dto = new List<BookingDTO>();

            model.ForEach(a=>dto.Add(new BookingDTO
            {
                Id = a.Id,
                BookingPeriodeStart = a.BookingPeriodeStart,
                BookingPeriodeSlut = a.BookingPeriodeSlut
            }));
            return dto;
        }

        [HttpGet("ByLokale/{lokaleId}/{searchDate}")]
        public IEnumerable<BookingDTO> GetBookingerByLokaleAndSearchDate(Guid lokaleId, DateTime searchDate)
        {
            var model = _getBookingUseCase.GetBookingerByLokaleBySearchDate(new GetBookingRequest
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

        [HttpGet("ByPerson/{personId}")]
        public IEnumerable<BookingDTO> GetCurrentBookingerByPerson(Guid personId)
        {
            var model = _getBookingUseCase.GetCurrentBookingerByPerson(new GetBookingRequest
                {PersonId = personId});
            var dto = new List<BookingDTO>();
            
            model.ForEach(a=>dto.Add(new BookingDTO
            {
                Id=a.Id,
                BookingPeriodeStart = a.BookingPeriodeStart,
                BookingPeriodeSlut = a.BookingPeriodeSlut,
                LokaleId =a.Lokale.Id,
                PersonId = a.Person.Id
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

        // PUT api/<Booking>/5
        [HttpPut("{id}")]
        public void PutBooking(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{bookingId}")]
        public void DeleteBooking(Guid bookingId)
        {
            _deleteBookingUseCase.DeleteBooking(new DeleteBookingRequest{Id = bookingId});
        }
    }
}
