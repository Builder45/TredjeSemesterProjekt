using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lokale;

namespace BeboerWeb.Application.UseCases.LokaleUC.Interfaces
{
    public interface ICreateLokaleUseCase
    {
        void CreateLokale(CreateLokaleRequest command);
    }
}
