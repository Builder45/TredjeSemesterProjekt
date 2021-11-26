using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.PersonUC
{
    public class UpdatePersonUseCase : IUpdatePersonUseCase
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void UpdatePerson(UpdatePersonRequest command)
        {
            var person = new Person(command.Fornavn, command.Efternavn, command.Telefonnr, command.BrugerId);
            person.Id = command.Id;
            _personRepository.UpdatePerson(person);
        }
    }
}
