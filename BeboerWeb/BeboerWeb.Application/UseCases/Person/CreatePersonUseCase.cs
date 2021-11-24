using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Implementation.Person
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
            var person = new Domain.Models.Person(command.Fornavn, command.Efternavn, command.Telefonnr, command.BrugerId);
            _personRepository.CreatePerson(person);
        }
    }
}
