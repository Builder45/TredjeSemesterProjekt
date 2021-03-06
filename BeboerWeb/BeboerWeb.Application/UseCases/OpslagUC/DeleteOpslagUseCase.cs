using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class DeleteOpslagUseCase : IDeleteOpslagUseCase
    {
        private readonly IOpslagRepository _repository;

        public DeleteOpslagUseCase(IOpslagRepository repository)
        {
            _repository = repository;
        }

        public void DeleteOpslag(DeleteOpslagRequest command)
        {
            var opslag = _repository.GetOpslag(command.Id);
            _repository.DeleteOpslag(opslag);
        }

    }
}
