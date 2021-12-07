﻿using System;
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
    public class CreateBookingUseCase : ICreateBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILokaleRepository _lokaleRepository;
        private readonly IPersonRepository _personRepository;
        public CreateBookingUseCase(IBookingRepository bookingRepository, ILokaleRepository lokaleRepository, IPersonRepository personRepository)
        {
            _bookingRepository = bookingRepository;
            _lokaleRepository = lokaleRepository;
            _personRepository = personRepository;
        }

        public void CreateBooking(CreateBookingRequest command)
        {
            var person = _personRepository.GetPerson(command.PersonId);
            var lokale = _lokaleRepository.GetLokale(command.LokaleId);
            var booking = new Booking(command.BookingPeriodeStart, command.BookingPeriodeStart, person, lokale);

            //Check for overlap mellem andre bookinger

            _bookingRepository.CreateBooking(booking);
        }
    }
}
