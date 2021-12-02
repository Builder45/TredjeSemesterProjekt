using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lokale;
using BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LokaleUC
{
    public class CreateLokaleUseCase : ICreateLokaleUseCase
    {
        private readonly ILokaleRepository _lokaleRepository;
        private readonly IEjendomRepository _ejendomRepository;

        public CreateLokaleUseCase(ILokaleRepository lokaleRepository, IEjendomRepository ejendomRepository)
        {
            _lokaleRepository = lokaleRepository;
            _ejendomRepository = ejendomRepository;
        }

        public void CreateLokale(CreateLokaleRequest command)
        {
            var ejendom = _ejendomRepository.GetEjendom(command.EjendomId);
            var lokale = new Lokale(command.Adresse, command.Etage, command.Areal, command.Timepris, command.Koekken, command.Badevaerelse, ejendom);
            _lokaleRepository.CreateLokale(lokale);
        }
    }
}
