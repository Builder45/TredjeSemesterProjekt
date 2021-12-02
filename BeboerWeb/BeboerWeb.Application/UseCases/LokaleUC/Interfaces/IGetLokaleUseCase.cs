using BeboerWeb.Domain.Models;
using BeboerWeb.Application.Requests.Lokale;

namespace BeboerWeb.Application.UseCases.LokaleUC.Interfaces;

public interface IGetLokaleUseCase
{
    Lokale GetLokale(GetLokaleRequest command);

    List<Lokale> GetLokalerInEjendom(GetLokaleRequest command);

    List<Lokale> GetLokaler();
}