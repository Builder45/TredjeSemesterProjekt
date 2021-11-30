using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;

namespace BeboerWeb.Application.UseCases.VicevaertUC
{
    public class AddVicevaertToEjendomUseCase : IAddVicevaertToEjendomUseCase
    {
        private readonly IVicevaertRepository _vicevaertRepository;

        public AddVicevaertToEjendomUseCase(IVicevaertRepository vicevaertRepository)
        {
            _vicevaertRepository = vicevaertRepository;
        }

        public void AddVicevaertToEjendom(AddVicevaertToEjendomRequest command)
        {
            _vicevaertRepository.AddVicevaertToEjendom(command.PersonId, command.EjendomId);
        }
    }
}
