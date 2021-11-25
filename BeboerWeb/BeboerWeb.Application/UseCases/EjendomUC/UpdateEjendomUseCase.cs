using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.EjendomUC
{
    public class UpdateEjendomUseCase : IUpdateEjendomUseCase
    {
        private readonly IEjendomRepository _ejendomRepository;

        public UpdateEjendomUseCase(IEjendomRepository ejendomRepository)
        {
            _ejendomRepository = ejendomRepository;
        }

        public void UpdateEjendom(UpdateEjendomRequest command)
        {
            var ejendom = new Ejendom(command.Adresse, command.Postnr, command.By);
            ejendom.Id = command.Id;
            _ejendomRepository.UpdateEjendom(ejendom);
        }
    }
}