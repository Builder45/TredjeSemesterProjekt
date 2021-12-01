using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejerUC.Interfaces
{
    public interface IUpdateLejerUseCase
    {
        Lejer UpdateLejer(UpdateLejerRequest command);
    }
}
