using BeboerWeb.Application.Requests;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface IGetPersonUseCase
    {
        Person GetPerson(GetPersonRequest command);
        List<Person> GetPersoner();
    }
}