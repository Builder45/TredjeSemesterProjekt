using BeboerWeb.Application.Requests.Booking;

namespace BeboerWeb.Application.UseCases.OpslagUC.Interfaces;

public interface IDeleteOpslagUseCase
{
    void DeleteOpslag(DeleteBookingRequest command);
}