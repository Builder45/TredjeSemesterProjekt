using BeboerWeb.Application.Requests.Booking;

namespace BeboerWeb.Application.UseCases.OpslagUC;

public interface IDeleteOpslagUseCase
{
    void DeleteOpslag(DeleteBookingRequest command);
}