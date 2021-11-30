using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract;

public interface ILejemaalService
{
    Task<List<LejemaalDTO>> GetLejemaalAsync();
    
    Task<LejemaalDTO> GetLejemaalByLejemaalIdAsync(Guid id);

    Task UpdateLejemaalAsync(LejemaalDTO lejemaal);

    //[HttpPost]
    public Task CreateLejemaal(LejemaalDTO dto);
}