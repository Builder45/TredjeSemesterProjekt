using BeboerWeb.Application.Requests.Ejendom;

namespace BeboerWeb.Application.UseCases.EjendomUC.Interfaces
{
    public interface IUpdateEjendomUseCase
    {
        void UpdateEjendom(UpdateEjendomRequest command);
    }
}