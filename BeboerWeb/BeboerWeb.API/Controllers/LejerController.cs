using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LejerController : ControllerBase
    {
        private readonly ICreateLejerUseCase _createLejerUseCase;
        private readonly IGetLejerUseCase _getLejerUseCase;
        private readonly IUpdateLejerUseCase _updateLejerUseCase;

        public LejerController(ICreateLejerUseCase createLejerUseCase, IGetLejerUseCase getLejerUseCase, IUpdateLejerUseCase updateLejerUseCase)
        {
            _createLejerUseCase = createLejerUseCase;
            _getLejerUseCase = getLejerUseCase;
            _updateLejerUseCase = updateLejerUseCase;
        }

        [HttpGet("{id}")]
        public LejerDTO GetLejer(Guid id)
        {
            var model = _getLejerUseCase.GetLejer(new GetLejerRequest {LejerId = id});

            var dto = new LejerDTO
            {
                Id = model.Id, 
                LejeperiodeStart = model.LejeperiodeStart, 
                LejeperiodeSlut = model.LejeperiodeSlut,
                LejemaalId = model.Lejemaal.Id,
            };

            foreach (var person in model.Personer)
            {
                dto.PersonIds.Add(person.Id);
            }

            return dto;
        }

        [HttpGet("ByBruger/{brugerId}")]
        public IEnumerable<LejerDTO> GetLejereByBruger(Guid brugerId)
        {
            var model = _getLejerUseCase.GetLejereByPerson(new GetLejerRequest {BrugerId = brugerId});
            var dtos = new List<LejerDTO>();
            model.ForEach(a =>dtos.Add(new LejerDTO
            {
                Id = a.Id,
                LejeperiodeStart = a.LejeperiodeStart,
                LejeperiodeSlut = a.LejeperiodeSlut,
                LejemaalId = a.Lejemaal.Id
            }));
            return dtos;
        }

        [HttpGet("ByLejemaal/{lejemaalId}")]
        public IEnumerable<LejerDTO> GetLejereByLejemaal(Guid lejemaalId)
        {
            var model = _getLejerUseCase.GetLejereByLejemaal(new GetLejerRequest {LejemaalId = lejemaalId });
            var dtos = new List<LejerDTO>();
            model.ForEach(a => dtos.Add(new LejerDTO
            {
                Id = a.Id,
                LejeperiodeStart = a.LejeperiodeStart,
                LejeperiodeSlut = a.LejeperiodeSlut,
                LejemaalId = a.Lejemaal.Id,
                LejerNavne = new List<string>()
            }));

            for (int i = 0; i < model.Count; i++)
            {
                foreach (var person in model[i].Personer)
                {
                    dtos[i].LejerNavne.Add($"{person.Fornavn} {person.Efternavn.Substring(0, 1)}. ");
                }
            }
            return dtos;
        }

        [HttpGet("ByEjendom/{ejendomId}")]
        public IEnumerable<LejerDTO> GetLejereByEjendom(Guid ejendomId)
        {
            var model = _getLejerUseCase.GetLejereByEjendom(new GetLejerRequest { EjendomId = ejendomId });
            var dtos = new List<LejerDTO>();
            model.ForEach(a => dtos.Add(new LejerDTO
            {
                Id = a.Id,
                LejeperiodeStart = a.LejeperiodeStart,
                LejeperiodeSlut = a.LejeperiodeSlut,
                LejemaalId = a.Lejemaal.Id
            }));
            return dtos;
        }

        [HttpPost]
        public void PostLejer([FromBody] LejerDTO dto)
        {
            _createLejerUseCase.CreateLejer(new CreateLejerRequest
                (dto.LejeperiodeStart, dto.LejeperiodeSlut, dto.LejemaalId, dto.PersonIds));
        }

        [HttpPut]
        public void PutLejer([FromBody] LejerDTO dto)
        {
            _updateLejerUseCase.UpdateLejer(new UpdateLejerRequest
                (dto.Id, dto.LejeperiodeStart, dto.LejeperiodeSlut, dto.LejemaalId, dto.PersonIds));
        }
    }
}
