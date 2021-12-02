using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<LejerController>/5
        [HttpGet("Lejemaal/{lejemaalId}")]
        public IEnumerable<LejerDTO>  GetLejereByLejemaal(Guid lejemaalId)
        {
            var model = _getLejerUseCase.GetLejereByLejemaal(new GetLejerRequest {LejemaalId = lejemaalId });
            var dto = new List<LejerDTO>();
            model.ForEach(a => dto.Add(new LejerDTO
            {
                Id = a.Id,
                LejeperiodeStart = a.LejeperiodeStart,
                LejeperiodeSlut = a.LejeperiodeSlut,
                LejemaalId = a.Lejemaal.Id
            }));
            return dto;
        }

        [HttpGet("Ejendom/{ejendomId}")]
        public IEnumerable<LejerDTO> GetLejereByEjendom(Guid ejendomId)
        {
            var model = _getLejerUseCase.GetLejereByEjendom(new GetLejerRequest { EjendomId = ejendomId });
            var dto = new List<LejerDTO>();
            model.ForEach(a => dto.Add(new LejerDTO
            {
                Id = a.Id,
                LejeperiodeStart = a.LejeperiodeStart,
                LejeperiodeSlut = a.LejeperiodeSlut,
                LejemaalId = a.Lejemaal.Id
            }));
            return dto;
        }


        // POST api/<LejerController>
        [HttpPost]
        public void Post([FromBody] LejerDTO dto)
        {
            _createLejerUseCase.CreateLejer(new CreateLejerRequest
                (dto.LejeperiodeStart, dto.LejeperiodeSlut, dto.LejemaalId, dto.PersonIds));
        }

        // PUT api/<LejerController>/5
        [HttpPut]
        public void Put([FromBody] LejerDTO dto)
        {
            _updateLejerUseCase.UpdateLejer(new UpdateLejerRequest(dto.Id, dto.LejeperiodeStart,dto.LejeperiodeSlut,dto.LejemaalId));
        }
    }
}
