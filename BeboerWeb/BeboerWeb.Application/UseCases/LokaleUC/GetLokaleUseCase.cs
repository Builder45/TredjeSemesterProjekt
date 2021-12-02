using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lokale;
using BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LokaleUC;

public class GetLokaleUseCase : IGetLokaleUseCase
{
    private readonly ILokaleRepository _repository;

    public GetLokaleUseCase(ILokaleRepository repository)
    {
        _repository = repository;
    }

    Lokale IGetLokaleUseCase.GetLokale(GetLokaleRequest command)
    {
        return _repository.GetLokale(command.LokaleId);
    }

    public List<Lokale> GetLokalerInEjendom(GetLokaleRequest command)
    {
        return _repository.GetLokalerByEjendom(command.EjendomId);
    }

    public List<Lokale> GetLokaler()
    {
        return _repository.GetLokaler();
    }

}