using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.API.Contract
{
    public interface IOpslagService
    {
        Task<List<OpslagDTO>> GetOpslagAsync();
        Task<OpslagDTO> GetOpslagAsync(Guid id);
        Task CreateOpslagAsync(OpslagDTO dto);
        Task UpdateOpslagAsync(OpslagDTO dto);
        Task DeleteOpslagAsync(Guid id);
    }
}
