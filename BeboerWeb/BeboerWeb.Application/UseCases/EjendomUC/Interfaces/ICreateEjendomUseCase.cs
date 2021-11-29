using BeboerWeb.Application.Requests.Ejendom;

namespace BeboerWeb.Application.UseCases.EjendomUC.Interfaces
{
    public interface ICreateEjendomUseCase
    {
        void CreateEjendom(CreateEjendomRequest command);
    }
}