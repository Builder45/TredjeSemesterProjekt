using BeboerWeb.Application.Requests.Person;
using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface ICreatePersonUseCase
    {
        void CreatePerson(CreatePersonRequest command);
    }
}