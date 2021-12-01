using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejerUC
{
    public class GetLejerUseCase : IGetLejerUseCase
    {
        public Lejer GetLejer(GetLejerRequest command)
        {
            throw new NotImplementedException();
        }

        public List<Lejer> GetLejere()
        {
            throw new NotImplementedException();
        }

        public List<Lejer> GetLejereByEjendom(GetLejerRequest command)
        {
            throw new NotImplementedException();
        }

        public List<Lejer> GetLejereByLejemaal(GetLejerRequest command)
        {
            throw new NotImplementedException();
        }
    }
}
