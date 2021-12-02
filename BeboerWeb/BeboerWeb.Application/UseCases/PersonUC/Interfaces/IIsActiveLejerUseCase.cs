using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Person;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface IIsActiveLejerUseCase
    {
        bool IsActiveLejer(IsActiveLejerRequest command);
    }
}
