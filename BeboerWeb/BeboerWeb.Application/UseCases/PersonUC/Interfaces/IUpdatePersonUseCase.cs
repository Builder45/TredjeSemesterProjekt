using BeboerWeb.Application.Requests.Person;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface IUpdatePersonUseCase
    {
        void UpdatePerson(UpdatePersonRequest command);
    }
}