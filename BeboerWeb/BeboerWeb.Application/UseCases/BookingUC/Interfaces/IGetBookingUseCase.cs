using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.BookingUC.Interfaces
{
    public interface IGetBookingUseCase
    {
        List<Booking> GetBookingerByLokaleBySearchDate(GetBookingRequest command);

        List<Booking> GetBookingerByLokale(GetBookingRequest command);

        List<Booking> GetCurrentBookingerByPerson(GetBookingRequest command);
    }
}
