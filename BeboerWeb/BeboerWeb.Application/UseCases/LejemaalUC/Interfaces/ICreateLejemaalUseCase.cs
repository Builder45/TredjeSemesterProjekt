using BeboerWeb.Application.Requests.Lejemaal;

namespace BeboerWeb.Application.UseCases.LejemaalUC.Interfaces
{
    public interface ICreateLejemaalUseCase
    {
        void CreateLejemaal(CreateLejemaalRequest command);
    }
}
