using BeboerWeb.Application.Requests.Opslag;

namespace BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

public interface IUpdateOpslagUseCase
{
    void UpdateOpslag(UpdateOpslagRequest command);
}