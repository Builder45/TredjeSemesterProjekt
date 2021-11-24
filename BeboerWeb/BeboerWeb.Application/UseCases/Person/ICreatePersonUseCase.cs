using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.Implementation.Person
{
    public interface ICreatePersonUseCase
    {
        void CreatePerson(CreatePersonRequest command);
    }
}