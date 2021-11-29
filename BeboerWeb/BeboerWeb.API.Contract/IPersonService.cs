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

        Task<List<PersonDTO>> GetPersonsAsync();

        Task<PersonDTO> GetPersonByUserIdAsync(Guid id);

        Task<PersonDTO> GetPersonByPersonIdAsync(Guid id);

        Task UpdatePersonAsync(PersonDTO person);

        //[HttpPost]
        public Task CreatePerson(PersonDTO dto);


    }
}
