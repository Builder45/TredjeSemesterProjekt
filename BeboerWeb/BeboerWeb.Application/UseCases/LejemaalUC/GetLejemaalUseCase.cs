using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejemaalUC
{
    public class GetLejemaalUseCase :IGetLejemaalUseCase
    {
        private readonly ILejemaalRepository _repository;

        public GetLejemaalUseCase(ILejemaalRepository repository)
        {
            _repository = repository;
        }

        Lejemaal IGetLejemaalUseCase.GetLejemaal(GetLejemaalRequest command)
        {
            return _repository.GetLejemaal(command.LejemaalId);
        }

        public List<Lejemaal> GetLejemaalsInEjendom(GetLejemaalRequest command)
        {
            return _repository.GetLejemaalsByEjendom(command.EjendomId);
        }

        public List<Lejemaal> GetLejemaals()
        {
            return _repository.GetLejemaals();
        }

    }
}
