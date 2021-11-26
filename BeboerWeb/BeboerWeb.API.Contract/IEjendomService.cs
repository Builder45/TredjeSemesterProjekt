using BeboerWeb.API.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract
{
    public interface IEjendomService
    {
        Task<List<EjendomDTO>> GetEjendommeAsync();

    }
}
