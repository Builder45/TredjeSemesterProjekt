using BeboerWeb.Application.Requests.Person;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface IGetPersonUseCase
    {
        Person GetPerson(GetPersonRequest command);
        Person GetPersonByUser(GetPersonByUserRequest command);
        List<Person> GetPersoner();
    }
}