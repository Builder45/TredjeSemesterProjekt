using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.UseCases.PersonUC.Interfaces;
using BeboerWeb.Application.Requests.Person;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ICreatePersonUseCase _createPersonUseCase;
        private readonly IGetPersonUseCase _getPersonUseCase;
        private readonly IUpdatePersonUseCase _updatePersonUseCase;
        private readonly IIsActiveLejerUseCase _isActiveLejerUseCase;

        public PersonController(ICreatePersonUseCase createPersonUseCase, IGetPersonUseCase getPersonUseCase, IUpdatePersonUseCase updatePersonUseCase, IIsActiveLejerUseCase isActiveLejerUseCase)
        {
            _createPersonUseCase = createPersonUseCase;
            _getPersonUseCase = getPersonUseCase;
            _updatePersonUseCase = updatePersonUseCase;
            _isActiveLejerUseCase = isActiveLejerUseCase;
        }

        [HttpGet]
        public IEnumerable<PersonDTO> GetPersoner()
        {
            var models = _getPersonUseCase.GetPersoner();
            var dtos = new List<PersonDTO>();
            models.ForEach(e => dtos.Add(new PersonDTO
            {
                Id = e.Id, 
                Fornavn = e.Fornavn, 
                Efternavn = e.Efternavn, 
                Telefonnr = e.Telefonnr, 
                BrugerId = e.BrugerId
            }));
            return dtos;
        }

        [HttpGet("{id}")]
        public PersonDTO GetPerson(Guid id)
        {
            var isActive = _isActiveLejerUseCase.IsLejer(new IsActiveLejerRequest(id));
            var model = _getPersonUseCase.GetPerson(new GetPersonRequest { Id = id });
            var dto = new PersonDTO
            {
                Id = model.Id, 
                Fornavn = model.Fornavn, 
                Efternavn = model.Efternavn, 
                Telefonnr = model.Telefonnr, 
                BrugerId = model.BrugerId, 
                IsActiveLejer = isActive
            };
            return dto;
        }

        [HttpGet("ByBruger/{brugerId}")]
        public PersonDTO GetPersonByBruger(Guid brugerId)
        {
            var model = _getPersonUseCase.GetPersonByUser(new GetPersonByUserRequest { BrugerId = brugerId });
            var isActive = _isActiveLejerUseCase.IsLejer(new IsActiveLejerRequest(model.Id));
            var dto = new PersonDTO
            {
                Id = model.Id, 
                Fornavn = model.Fornavn, 
                Efternavn = model.Efternavn, 
                Telefonnr = model.Telefonnr, 
                BrugerId = model.BrugerId, 
                IsActiveLejer = isActive
            };
            return dto;
        }

        [HttpPost]
        public void PostPerson([FromBody] PersonDTO dto)
        {
            _createPersonUseCase.CreatePerson(new CreatePersonRequest
                (dto.Fornavn, dto.Efternavn, dto.Telefonnr, dto.BrugerId));
        }

        [HttpPut]
        public void PutPerson([FromBody] PersonDTO dto)
        {
            _updatePersonUseCase.UpdatePerson(new UpdatePersonRequest
                (dto.Id, dto.Fornavn, dto.Efternavn, dto.Telefonnr, dto.BrugerId));
        }
    }
}
