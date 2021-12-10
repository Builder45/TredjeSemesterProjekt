using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class CreateOpslagUseCase : ICreateOpslagUseCase
    {
        private readonly IOpslagRepository _repository;

        public CreateOpslagUseCase(IOpslagRepository repository)
        {
            _repository = repository;
        }

        public void CreateOpslag(CreateOpslagRequest command)
        {
            var id = _repository.CreateOpslag(new Opslag(command.Dato, command.Titel, command.Besked));
            if (command.EjendomIds.Count > 0)
            {
                foreach (var ejendomId in command.EjendomIds)
                {
                    _repository.LinkOpslagWithEjendom(id, ejendomId);
                }
            }
        }
    }
}
