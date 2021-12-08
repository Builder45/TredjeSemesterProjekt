using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetBookingerByLokaleAsync(Guid lokaleId, DateTime searchDate);
        Task CreateBookingAsync(BookingDTO dto);
    }
}
