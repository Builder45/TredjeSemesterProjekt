using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Application.UseCases.BookingUC.Interfaces;

namespace BeboerWeb.Application.UseCases.BookingUC
{
    public class DeleteBookingUseCase : IDeleteBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;
        public DeleteBookingUseCase(IBookingRepository repository)
        {
            _bookingRepository = repository;
        }

        public void DeleteBooking(DeleteBookingRequest command)
        {
            var booking = _bookingRepository.GetBooking(command.Id);

            if (booking.IsOldOrStarted())
                throw new Exception("Bookingen er enten startet eller gammel.");

            _bookingRepository.DeleteBooking(booking);
        }
    }
}
