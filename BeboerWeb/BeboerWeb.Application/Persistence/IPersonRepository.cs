using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Persistence
{
    public interface IPersonRepository
    {
        void CreatePerson(Person person);
        Person GetPerson(Guid id);
        Person GetPersonByUser(Guid brugerId);
        List<Person> GetPersoner();
        void UpdatePerson(Person person);
    }
}
