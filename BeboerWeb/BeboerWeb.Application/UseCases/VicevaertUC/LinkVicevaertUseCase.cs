using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.VicevaertUC
{
    public class LinkVicevaertUseCase : ILinkVicevaertUseCase
    {
        private readonly IVicevaertRepository _vicevaertRepository;
        private readonly IPersonRepository _personRepository;

        public LinkVicevaertUseCase(IVicevaertRepository vicevaertRepository, IPersonRepository personRepository)
        {
            _vicevaertRepository = vicevaertRepository;
            _personRepository = personRepository;
        }

        public void LinkVicevaert(LinkVicevaertRequest command)
        {
            var vicevaert = GetVicevaertWithPerson(command.PersonId);
            _vicevaertRepository.LinkVicevaert(vicevaert);
        }

        public void UnlinkVicevaert(LinkVicevaertRequest command)
        {
            var vicevaert = GetVicevaertWithPerson(command.PersonId);
            _vicevaertRepository.UnlinkVicevaert(vicevaert);
        }

        private Vicevaert GetVicevaertWithPerson(Guid id)
        {
            var person = _personRepository.GetPerson(id);
            var vicevaert = new Vicevaert
            {
                Person = person
            };
            return vicevaert;
        }
    }
}
