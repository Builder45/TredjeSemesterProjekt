using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface IVicevaertService
    {
        Task LinkVicevaertAsync(VicevaertDTO dto);
        Task UnlinkVicevaertAsync(VicevaertDTO dto);
    }
}
