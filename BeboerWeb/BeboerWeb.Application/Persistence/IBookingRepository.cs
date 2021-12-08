using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IBookingRepository
    {
        List<Booking> GetBookingerByLokaleBySearchDate(Guid lokaleId, DateTime searchDate);
        List<Booking> GetBookingerByLokale(Guid lokaleId);
        List<Booking> GetCurrentBookingerByPerson(Guid personId);
        void CreateBooking(Booking booking);
    }
}
