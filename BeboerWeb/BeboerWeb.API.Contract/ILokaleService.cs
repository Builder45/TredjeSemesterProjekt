using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface ILokaleService
    {
        Task<List<LokaleDTO>> GetLokalerAsync();
        Task<LokaleDTO> GetLokaleAsync(Guid id);
        Task CreateLokaleAsync(LokaleDTO dto);
        Task UpdateLokaleAsync(LokaleDTO dto);
    }
}
