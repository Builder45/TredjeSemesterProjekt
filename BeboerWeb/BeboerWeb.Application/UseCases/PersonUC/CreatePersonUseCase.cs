using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.PersonUC
{
    public class CreatePersonUseCase : ICreatePersonUseCase
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void CreatePerson(CreatePersonRequest command)
        {
            var person = new Person(command.Fornavn, command.Efternavn, command.Telefonnr, command.BrugerId);
            _personRepository.CreatePerson(person);
        }
    }
}
