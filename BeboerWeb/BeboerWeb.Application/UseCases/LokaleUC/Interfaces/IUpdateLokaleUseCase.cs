using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.Requests.Lokale;


namespace BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
public interface IUpdateLokaleUseCase 
{
    void UpdateLokale(UpdateLokaleRequest command);
}