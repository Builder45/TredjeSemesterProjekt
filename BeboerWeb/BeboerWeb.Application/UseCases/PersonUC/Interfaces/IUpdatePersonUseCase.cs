using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.UseCases.PersonUC.Interfaces
{
    public interface IUpdatePersonUseCase
    {
        void UpdatePerson(UpdatePersonRequest command);
    }
}