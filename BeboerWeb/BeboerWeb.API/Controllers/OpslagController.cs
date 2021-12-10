using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Booking;
using BeboerWeb.Application.Requests.Opslag;
using BeboerWeb.Application.UseCases.OpslagUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpslagController : ControllerBase
    {
        private readonly IGetOpslagUseCase _getOpslagUseCase;
        private readonly ICreateOpslagUseCase _createOpslagUseCase;
        private readonly IUpdateOpslagUseCase _updateOpslagUseCase;
        private readonly IDeleteOpslagUseCase _deleteOpslagUseCase;

        public OpslagController(IGetOpslagUseCase getOpslagUseCase, ICreateOpslagUseCase createOpslagUseCase, IUpdateOpslagUseCase updateOpslagUseCase, IDeleteOpslagUseCase deleteOpslagUseCase)
        {
            _getOpslagUseCase = getOpslagUseCase;
            _createOpslagUseCase = createOpslagUseCase;
            _updateOpslagUseCase = updateOpslagUseCase;
            _deleteOpslagUseCase = deleteOpslagUseCase; 
        }

        [HttpGet]
        public IEnumerable<OpslagDTO> GetAllOpslag()
        {
            var models = _getOpslagUseCase.GetAllOpslag();
            var dtos = new List<OpslagDTO>();
            models.ForEach(o => dtos.Add(new OpslagDTO
            {
                Id = o.Id,
                Titel = o.Titel,
                Besked = o.Besked,
                Dato = o.Dato
            }));
            return dtos;
        }

        [HttpGet("{id}")]
        public OpslagDTO GetOpslag(Guid id)
        {
            var model = _getOpslagUseCase.GetOpslag(new GetOpslagRequest(id));
            var dto = new OpslagDTO
            {
                Id = model.Id,
                Titel = model.Titel,
                Besked = model.Besked,
                Dato = model.Dato
            };

            foreach (var ejendom in model.Ejendomme)
            {
                dto.EjendomIds.Add(ejendom.Id);
            }

            return dto;
        }

        [HttpPost]
        public void PostOpslag([FromBody] OpslagDTO dto)
        {
            _createOpslagUseCase.CreateOpslag(new CreateOpslagRequest(dto.Dato, dto.Titel, dto.Besked, dto.EjendomIds));
        }

        [HttpPut]
        public void PutOpslag([FromBody] OpslagDTO dto)
        {
            _updateOpslagUseCase.UpdateOpslag(new UpdateOpslagRequest(dto.Id, dto.Dato, dto.Titel, dto.Besked, dto.EjendomIds));
        }

        [HttpDelete("{id}")]
        public void DeleteOpslag(Guid id)
        {
            _deleteOpslagUseCase.DeleteOpslag(new DeleteOpslagRequest(id));
        }
    }
}
