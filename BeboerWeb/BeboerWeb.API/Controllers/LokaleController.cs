using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lokale;
using BeboerWeb.Application.UseCases.LokaleUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokaleController : ControllerBase
    {
        private readonly ICreateLokaleUseCase _createLokaleUseCase;
        private readonly IGetLokaleUseCase _getLokaleUseCase;
        private readonly IUpdateLokaleUseCase _updateLokaleUseCase;

        public LokaleController(ICreateLokaleUseCase createLokaleUseCase, IGetLokaleUseCase getLokaleUseCase,
            IUpdateLokaleUseCase updateLokaleUseCase)
        {
            _createLokaleUseCase = createLokaleUseCase;
            _getLokaleUseCase = getLokaleUseCase;
            _updateLokaleUseCase = updateLokaleUseCase;
        }

        [HttpGet("ByEjendom/{ejendomId}")]
        public IEnumerable<LokaleDTO> GetLokalerByEjendom(Guid ejendomId)
        {
            var model = _getLokaleUseCase.GetLokalerInEjendom(new GetLokaleRequest {EjendomId = ejendomId});
            var dto = new List<LokaleDTO>();
            model.ForEach(a => dto.Add(new LokaleDTO
            {
                Id = a.Id,
                Navn = a.Navn,
                Adresse = a.Adresse,
                Etage = a.Etage,
                Areal = a.Areal,
                Timepris = a.Timepris,
                Koekken = a.Koekken,
                Badevaerelse = a.Badevaerelse,
                EjendomId = a.Ejendom.Id
            }));
            return dto;
        }

        [HttpGet]
        public IEnumerable<LokaleDTO> GetLokaler()
        {
            var model = _getLokaleUseCase.GetLokaler();
            var dto = new List<LokaleDTO>();
            model.ForEach(a => dto.Add(new LokaleDTO()
            {
                Id = a.Id,
                Navn = a.Navn,
                Adresse = a.Adresse,
                Etage = a.Etage,
                Areal = a.Areal,
                Timepris = a.Timepris,
                Koekken = a.Koekken,
                Badevaerelse = a.Badevaerelse,
                EjendomId = a.Ejendom.Id
            }));
            return dto;
        }

        [HttpGet("{id}")]
        public LokaleDTO GetLokale(Guid id)
        {
            var model = _getLokaleUseCase.GetLokale(new GetLokaleRequest {LokaleId = id});
            var dto = new LokaleDTO()
            {
                Id = model.Id, Navn = model.Navn, Adresse = model.Adresse, Etage = model.Etage, Areal = model.Areal,
                Timepris = model.Timepris, Koekken = model.Koekken, Badevaerelse = model.Badevaerelse,
                EjendomId = model.Ejendom.Id
            };
            return dto;
        }

        [HttpPost]
        public void PostLokale([FromBody] LokaleDTO dto)
        {
            _createLokaleUseCase.CreateLokale(new CreateLokaleRequest(dto.Navn, dto.Adresse, dto.Etage, dto.Areal, dto.Timepris, dto.Koekken, dto.Badevaerelse,dto.EjendomId));
        }

        [HttpPut]
        public void PutLokale([FromBody] LokaleDTO dto)
        {
            _updateLokaleUseCase.UpdateLokale(new UpdateLokaleRequest(dto.Id, dto.Navn, dto.Adresse, dto.Etage, dto.Areal, dto.Timepris, dto.Koekken, dto.Badevaerelse, dto.EjendomId));
        }
    }
}
