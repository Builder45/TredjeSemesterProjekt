using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface ILejerService
    {
        Task<List<LejerDTO>> GetLejereByEjendomAsync(Guid id);
        Task<List<LejerDTO>> GetLejereByLejemaalAsync(Guid id);
        Task<LejerDTO> GetLejerAsync(Guid id);
        Task CreateLejerAsync(LejerDTO dto);
        Task UpdateLejerAsync(LejerDTO dto);
    }
}
