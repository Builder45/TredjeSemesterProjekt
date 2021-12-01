using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lejer;

namespace BeboerWeb.Application.UseCases.LejerUC.Interfaces
{
    public interface ICreateLejerUseCase
    {
        void CreateLejer(CreateLejerRequest command);
    }
}
