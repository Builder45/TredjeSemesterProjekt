using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.UseCases.EjendomUC.Interfaces
{
    public interface ICreateEjendomUseCase
    {
        void CreateEjendom(CreateEjendomRequest command);
    }
}