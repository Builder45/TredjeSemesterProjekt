using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetBookingerByLokaleAndSearchDateAsync(Guid lokaleId, DateTime searchDate);
        Task<List<BookingDTO>> GetBookingerByBrugerAsync(Guid lokaleId);
        Task CreateBookingAsync(BookingDTO dto);
        Task DeleteBookingAsync(Guid id);
    }
}
