using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lokale;
using BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LokaleUC;

public class UpdateLokaleUseCase : IUpdateLokaleUseCase
{
    private readonly ILokaleRepository _lokaleRepository;
    private readonly IEjendomRepository _ejendomRepository;

    public UpdateLokaleUseCase(ILokaleRepository lokaleRepository, IEjendomRepository ejendomRepository)
    {
        _lokaleRepository = lokaleRepository;
        _ejendomRepository = ejendomRepository;
    }

    public void UpdateLokale(UpdateLokaleRequest command)
    {
        var ejendom = _ejendomRepository.GetEjendom(command.EjendomId);
        var lokale = new Lokale(command.Navn, command.Adresse, command.Etage, command.Areal, command.Timepris, command.Koekken, command.Badevaerelse, ejendom);

        lokale.Id = command.Id;
        _lokaleRepository.UpdateLokale(lokale);
    }
}