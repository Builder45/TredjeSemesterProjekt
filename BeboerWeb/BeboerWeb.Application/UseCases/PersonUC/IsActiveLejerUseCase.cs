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

        public bool IsActiveLejer(IsActiveLejerRequest command)
        {
            var person = _personRepository.GetPerson(command.Id);

            var activeLejer = false;

            foreach (var lejer in person.Lejere)
            {
                if (DateTime.Now > lejer.LejeperiodeStart && DateTime.Now < lejer.LejeperiodeSlut)
                {
                    activeLejer = true;
                }
            }
            return activeLejer;
        }

    }
}
