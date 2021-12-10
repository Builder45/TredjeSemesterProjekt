using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

public interface IGetOpslagUseCase
{
    Opslag GetOpslag(GetOpslagRequest command);
    List<Opslag> GetAllOpslag();
}