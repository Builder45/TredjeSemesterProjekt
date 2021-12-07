using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Application.UseCases.BookingUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        //private readonly ICreateBookingUseCase _createBookingUseCase;
        private readonly IGetBookingUseCase _getBookingUseCase;
        //private readonly IUpdateBookingUseCase _updateBookingUseCase;

        public BookingController(IGetBookingUseCase getBookingUseCase)//, ICreateBookingUseCase createBookingUseCase, IUpdateBookingUseCase updateBookingUseCase)
        {
            //_createBookingUseCase = createBookingUseCase;
            _getBookingUseCase = getBookingUseCase;
            //_updateBookingUseCase = updateBookingUseCase;
        }

        // GET: api/<Booking>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{lokaleId}/{searchDate}")]
        public IEnumerable<BookingDTO> GetAllBookingerByLokaleBySearchDate(Guid lokaleId, DateTime searchDate)
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

        // GET api/<Booking>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Booking>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Booking>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Booking>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
