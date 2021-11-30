using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface IVicevaertService
    {
        Task LinkVicevaert(VicevaertDTO dto);
        Task UnlinkVicevaert(VicevaertDTO dto);
    }
}
