using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;

public interface IGetVicevaertUseCase
{
    List<Vicevaert> GetRelevantVicevaerterByBruger(GetVicevaertRequest command);
}