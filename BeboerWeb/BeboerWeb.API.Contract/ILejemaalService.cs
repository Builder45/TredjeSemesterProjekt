using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract;

public interface ILejemaalService
{
    Task<List<LejemaalDTO>> GetLejemaalsAsync();
    
    Task<LejemaalDTO> GetLejemaalAsync(Guid id);

    Task UpdateLejemaalAsync(LejemaalDTO lejemaal);

    public Task CreateLejemaalAsync(LejemaalDTO dto);

    Task<List<LejemaalDTO>> GetLejemaalsByBrugerAsync(Guid id);
}