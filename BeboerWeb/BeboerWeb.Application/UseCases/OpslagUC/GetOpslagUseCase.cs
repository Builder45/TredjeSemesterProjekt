using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class GetOpslagUseCase : IGetOpslagUseCase
    {
        private readonly IOpslagRepository _repository;

        public GetOpslagUseCase(IOpslagRepository repository)
        {
            _repository = repository;
        }

        public Opslag GetOpslag(GetOpslagRequest command)
        {
            return _repository.GetOpslag(command.Id);
        }

        public List<Opslag> GetAllOpslag()
        {
            return _repository.GetAllOpslag();
        }
    }
}
