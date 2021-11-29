using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.EjendomUC
{
    public class CreateEjendomUseCase : ICreateEjendomUseCase
    {
        private readonly IEjendomRepository _ejendomRepository;

        public CreateEjendomUseCase(IEjendomRepository ejendomRepository)
        {
            _ejendomRepository = ejendomRepository;
        }

        public void CreateEjendom(CreateEjendomRequest command)
        {
            var ejendom = new Ejendom(command.Adresse, command.Postnr, command.By);
            _ejendomRepository.CreateEjendom(ejendom);
        }
    }
}
