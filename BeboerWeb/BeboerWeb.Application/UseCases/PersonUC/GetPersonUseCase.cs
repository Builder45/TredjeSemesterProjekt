using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.Requests.Person;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.PersonUC
{
    public class GetPersonUseCase : IGetPersonUseCase
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPerson(GetPersonRequest command)
        {
            return _personRepository.GetPerson(command.Id);
        }

        public Person GetPersonByUser(GetPersonByUserRequest command)
        {
            return _personRepository.GetPersonByUser(command.BrugerId);
        }

        public List<Person> GetPersoner()
        {
            return _personRepository.GetPersoner();
        }
    }
}
