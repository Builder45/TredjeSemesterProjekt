using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Application.UseCases.BookingUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.BookingUC
{
    public class GetBookingUseCase:IGetBookingUseCase
    {

        private readonly IBookingRepository _bookingRepository;

        public GetBookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<Booking> GetBookingerByLokaleBySearchDate(GetBookingRequest command)
        {
            return _bookingRepository.GetBookingerByLokaleBySearchDate(command.LokaleId, command.SearchDate);
        }

        public List<Booking> GetBookingerByLokale(GetBookingRequest command)
        {
            return _bookingRepository.GetBookingerByLokale(command.LokaleId);
        }
    }
}
