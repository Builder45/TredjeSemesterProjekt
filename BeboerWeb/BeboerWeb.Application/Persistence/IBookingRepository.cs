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
        List<Booking> GetAllBookingerByLokaleBySearchDate(Guid lokaleId, DateTime searchDate);

    }
}
