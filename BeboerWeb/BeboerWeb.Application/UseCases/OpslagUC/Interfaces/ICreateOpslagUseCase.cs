using BeboerWeb.Application.Requests.Opslag;

namespace BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

public interface ICreateOpslagUseCase
{
    void CreateOpslag(CreateOpslagRequest command);
}