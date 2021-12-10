using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class UpdateOpslagUseCase : IUpdateOpslagUseCase
    {
        private readonly IOpslagRepository _repository;

        public UpdateOpslagUseCase(IOpslagRepository repository)
        {
            _repository = repository;
        }

        public void UpdateOpslag(UpdateOpslagRequest command)
        {
            var opslag = new Opslag(command.Dato, command.Titel, command.Besked);
            opslag.Id = command.Id;

            _repository.UpdateOpslag(opslag);
            _repository.UnlinkOpslagWithEjendomme(command.Id);

            if (command.EjendomIds.Count > 0)
            {
                foreach (var ejendomId in command.EjendomIds)
                {
                    _repository.LinkOpslagWithEjendom(command.Id, ejendomId);
                }
            }
        }
    }
}
