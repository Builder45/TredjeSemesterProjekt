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

        public List<Booking> GetCurrentBookingerByPerson(Guid personId)
        {
            var currentDate = DateTime.Now;
            var person = _db.Person
                .Include(a => a.Bookinger
                .Where(s=>s.BookingPeriodeStart >= currentDate|| s.BookingPeriodeSlut >= currentDate ))
                .ThenInclude(a=>a.Lokale)
                .FirstOrDefault(a => a.Id == personId);

            if (person == null)
            {
                throw new NullReferenceException("Ingen personer fundet");
            }

            return person.Bookinger;
        }
        public List<Booking> GetBookingerByLokaleBySearchDate(Guid lokaleId, DateTime searchDate)
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

        public List<Booking> GetBookingerByLokale(Guid lokaleId)
        {
            var lokale = _db.Lokale
                .Include(a => a.Bookinger)
                .FirstOrDefault(a => a.Id == lokaleId);

            if (lokale == null)
            {
                throw new NullReferenceException("Ingen lokaler fundet");
            }

            return lokale.Bookinger;
        }

        public void CreateBooking(Booking booking)
        {
            _db.Add(booking);
            _db.SaveChanges();
        }
    }
}