using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.Implementation.PersonUC
{
    public interface ICreatePersonUseCase
    {
        void CreatePerson(CreatePersonRequest command);
    }
}