using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Implementation.Person;
using BeboerWeb.Application.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ICreatePersonUseCase _createPersonUseCase;

        public PersonController(ICreatePersonUseCase createPersonUseCase)
        {
            _createPersonUseCase = createPersonUseCase;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] PersonDTO dto)
        {
            _createPersonUseCase.CreatePerson(new OpretPersonRequest(dto.Fornavn, dto.Efternavn, dto.Telefonnr, dto.BrugerId));
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
