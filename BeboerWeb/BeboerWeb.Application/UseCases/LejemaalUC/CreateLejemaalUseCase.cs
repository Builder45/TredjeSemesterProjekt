using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejemaalUC
{
    public class CreateLejemaalUseCase : ICreateLejemaalUseCase
    {
        private readonly ILejemaalRepository _lejemaalRepository;
        private readonly IEjendomRepository _ejendomRepository;


        public CreateLejemaalUseCase(ILejemaalRepository lejemaalRepository, IEjendomRepository ejendomRepository)
        {
            _lejemaalRepository = lejemaalRepository;
            _ejendomRepository = ejendomRepository;
        }

        public void CreateLejemaal (CreateLejemaalRequest command)
        {
            var ejendom = _ejendomRepository.GetEjendom(command.EjendomId);
            var lejemaal = new Lejemaal (command.Adresse, command.Etage, command.Husleje, command.Areal, command.Koekken, command.Badevaerelse, ejendom);
            _lejemaalRepository.CreateLejemaal(lejemaal); 
        }
    }
}
