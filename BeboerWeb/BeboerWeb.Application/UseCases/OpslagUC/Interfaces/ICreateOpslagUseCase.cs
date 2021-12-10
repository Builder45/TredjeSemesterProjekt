using BeboerWeb.Application.Requests.Opslag;

namespace BeboerWeb.Application.UseCases.OpslagUC;

public interface ICreateOpslagUseCase
{
    void CreateOpslag(CreateOpslagRequest command);
}