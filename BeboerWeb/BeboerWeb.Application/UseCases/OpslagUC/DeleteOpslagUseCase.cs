using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Booking;

namespace BeboerWeb.Application.UseCases.OpslagUC
{
    public class DeleteOpslagUseCase
    {
        private readonly IOpslagRepository _repository;

        public DeleteOpslagUseCase(IOpslagRepository repository)
        {
            _repository = repository;
        }

        public void DeleteOpslag(DeleteBookingRequest command)
        {
            var opslag = _repository.GetOpslag(command.Id);
            _repository.DeleteOpslag(opslag);
        }

    }
}
