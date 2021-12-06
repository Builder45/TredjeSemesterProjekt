using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejerUC.Interfaces
{
    public interface IGetLejerUseCase
    {
        Lejer GetLejer(GetLejerRequest command);

        List<Lejer> GetLejereByPerson (GetLejerRequest command);

        List<Lejer> GetLejere();

        List<Lejer> GetLejereByEjendom(GetLejerRequest command);

        List<Lejer> GetLejereByLejemaal(GetLejerRequest command);
        


    }
}
