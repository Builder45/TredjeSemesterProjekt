using BeboerWeb.API.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeboerWeb.API.Contract
{
    public interface IPersonService
    {

        Task<List<PersonDTO>> GetPersonAsync();

        //[HttpPost]
        public Task CreatePerson(PersonDTO dto);
    }
}
