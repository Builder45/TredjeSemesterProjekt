using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejemaalUC.Interfaces
{
    public interface IGetLejemaalUseCase
    {
        Lejemaal GetLejemaal(GetLejemaalRequest command);

        List<Lejemaal> GetLejemaalsInEjendom(GetLejemaalRequest command);

        List<Lejemaal> GetLejemaals();

    }
}
