using BeboerWeb.Application.Requests.Opslag;

namespace BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

public interface IDeleteOpslagUseCase
{
    void DeleteOpslag(DeleteOpslagRequest command);
}