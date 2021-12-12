using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class GetOpslagUseCase : IGetOpslagUseCase
    {
        private readonly IOpslagRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly IEjendomRepository _ejendomRepository;

        public GetOpslagUseCase(IOpslagRepository repository, IPersonRepository personRepository, IEjendomRepository ejendomRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
            _ejendomRepository = ejendomRepository;
        }

        public Opslag GetOpslag(GetOpslagRequest command)
        {
            return _repository.GetOpslag(command.Id);
        }

        public List<Opslag> GetAllOpslag()
        {
            return _repository.GetAllOpslag();
        }

        public List<Opslag> GetOpslagByBruger(GetOpslagRequest command)
        {
            var person = _personRepository.GetPersonByUser(command.BrugerId);
            var ejendomme = _ejendomRepository.GetEjendommeByPerson(person.Id);
            return _repository.GetOpslagByEjendomme(ejendomme);
        }
    }
}
