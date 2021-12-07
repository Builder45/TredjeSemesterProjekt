using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BeboerWebContext _db;
        public BookingRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public List<Booking> GetAllBookingerByLokaleBySearchDate(Guid lokaleId, DateTime searchDate)
        {
            var lokale = _db.Lokale
                .Include(a => a.Bookinger
                    .Where(s => s.BookingPeriodeStart.Year == searchDate.Year|| s.BookingPeriodeSlut.Year == searchDate.Year)
                    .Where(s => s.BookingPeriodeStart.Month == searchDate.Month|| s.BookingPeriodeSlut.Month == searchDate.Month))
                .FirstOrDefault(a => a.Id == lokaleId);
            if (lokale == null)
            {
                throw new NullReferenceException("Ingen lokaler fundet");
            }
            return lokale.Bookinger;
        }
    }
}