using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Person;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;

namespace BeboerWeb.Application.UseCases.PersonUC
{
    public class IsActiveLejerUseCase : IIsActiveLejerUseCase
    {
        private readonly IPersonRepository _personRepository;

        public IsActiveLejerUseCase(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public bool IsLejer(IsActiveLejerRequest command)
        {
            var person = _personRepository.GetPerson(command.Id);

            bool isLejer = (person.Lejere == null || person.Lejere.Count == 0);

            return !isLejer;
        }

    }
}
