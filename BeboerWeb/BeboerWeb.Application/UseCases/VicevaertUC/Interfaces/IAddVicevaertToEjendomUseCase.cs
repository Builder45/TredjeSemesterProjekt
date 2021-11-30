using BeboerWeb.Application.Requests.Vicevaert;

namespace BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;

public interface IAddVicevaertToEjendomUseCase
{
    void AddVicevaertToEjendom(AddVicevaertToEjendomRequest command);
}