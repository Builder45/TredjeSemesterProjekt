using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.Requests.Lejemaal;

namespace BeboerWeb.Application.UseCases.LejemaalUC.Interfaces
{
    public interface IUpdateLejemaalUseCase
    {
        void UpdateLejemaal(UpdateLejemaalRequest command);
    }
}
