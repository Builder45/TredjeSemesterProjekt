using BeboerWeb.Application.Requests;

namespace BeboerWeb.Application.UseCases.EjendomUC.Interfaces
{
    public interface IUpdateEjendomUseCase
    {
        void UpdateEjendom(UpdateEjendomRequest command);
    }
}