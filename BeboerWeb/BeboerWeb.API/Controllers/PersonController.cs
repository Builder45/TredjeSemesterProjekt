using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
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
        private readonly IGetPersonUseCase _getPersonUseCase;
        private readonly IUpdatePersonUseCase _updatePersonUseCase;

        public PersonController(ICreatePersonUseCase createPersonUseCase, IGetPersonUseCase getPersonUseCase, IUpdatePersonUseCase updatePersonUseCase)
        {
            _createPersonUseCase = createPersonUseCase;
            _getPersonUseCase = getPersonUseCase;
            _updatePersonUseCase = updatePersonUseCase;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonDTO> Get()
        {
            var models = _getPersonUseCase.GetPersoner();
            var dtos = new List<PersonDTO>();
            models.ForEach(e => dtos.Add(new PersonDTO
                { Id = e.Id, Fornavn = e.Fornavn, Efternavn = e.Efternavn, Telefonnr = e.Telefonnr, BrugerId = e.BrugerId }));

            return dtos;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public PersonDTO Get(Guid id)
        {
            var model = _getPersonUseCase.GetPerson(new GetPersonRequest { Id = id });
            var dto = new PersonDTO 
                { Id = model.Id, Fornavn = model.Fornavn, Efternavn = model.Efternavn, Telefonnr = model.Telefonnr, BrugerId = model.BrugerId };

            return dto;
        }

        // GET api/<PersonController>/5
        [HttpGet("ByUser/{brugerId}")]
        public PersonDTO GetByUser(Guid brugerId)
        {
            var model = _getPersonUseCase.GetPersonByUser(new GetPersonByUserRequest { BrugerId = brugerId });
            var dto = new PersonDTO
            { Id = model.Id, Fornavn = model.Fornavn, Efternavn = model.Efternavn, Telefonnr = model.Telefonnr, BrugerId = model.BrugerId };

            return dto;
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] PersonDTO dto)
        {
            _createPersonUseCase.CreatePerson(new CreatePersonRequest(dto.Fornavn, dto.Efternavn, dto.Telefonnr, dto.BrugerId));
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public void Put([FromBody] PersonDTO dto)
        {
            _updatePersonUseCase.UpdatePerson(new UpdatePersonRequest(dto.Id, dto.Fornavn, dto.Efternavn, dto.Telefonnr, dto.BrugerId));
        }

        //// DELETE api/<PersonController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
