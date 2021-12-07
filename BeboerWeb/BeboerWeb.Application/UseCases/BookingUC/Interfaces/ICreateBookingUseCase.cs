using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Booking;

namespace BeboerWeb.Application.UseCases.BookingUC.Interfaces
{
    public interface ICreateBookingUseCase
    {
        void CreateBooking(CreateBookingRequest command);
    }
}
