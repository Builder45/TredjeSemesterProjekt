using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjendomController : ControllerBase
    {
        private readonly ICreateEjendomUseCase _createEjendomUseCase;
        private readonly IGetEjendomUseCase _getEjendomUseCase;
        private readonly IUpdateEjendomUseCase _updateEjendomUseCase;

        public EjendomController(ICreateEjendomUseCase createEjendomUseCase, IGetEjendomUseCase getEjendomUseCase, IUpdateEjendomUseCase updateEjendomUseCase)
        {
            _createEjendomUseCase = createEjendomUseCase;
            _getEjendomUseCase = getEjendomUseCase;
            _updateEjendomUseCase = updateEjendomUseCase;
        }

        // GET: api/<EjendomController>
        [HttpGet]
        public IEnumerable<EjendomDTO> Get()
        {
            var models = _getEjendomUseCase.GetEjendomme();
            var dtos = new List<EjendomDTO>();
            models.ForEach(e => dtos.Add(new EjendomDTO
                { Id = e.Id, Adresse = e.Adresse, Postnr = e.Postnr, By = e.By}));

            return dtos;
        }

        [HttpGet("/Lokaler")]
        public IEnumerable<EjendomDTO> GetWithLokaler()
        {
            var models = _getEjendomUseCase.GetEjendommeWithLokaler();
            var dtos = new List<EjendomDTO>();
            models.ForEach(e => dtos.Add(new EjendomDTO
                { Id = e.Id, Adresse = e.Adresse, Postnr = e.Postnr, By = e.By}));

            foreach (var model in models)
            {
                var dto = new EjendomDTO {Id = model.Id, Adresse = model.Adresse, Postnr = model.Postnr, By = model.By};
                var lokaleDtos = new List<LokaleDTO>();
                model.Lokaler.ForEach(e => lokaleDtos.Add(new LokaleDTO
                {
                    Id = e.Id,
                    Adresse = e.Adresse, 
                    Etage = e.Etage, 
                    Areal = e.Areal, 
                    Badevaerelse = e.Badevaerelse, 
                    Koekken = e.Koekken,
                    Timepris = e.Timepris,
                    EjendomId = e.Ejendom.Id
                }));
                dto.Lokaler = lokaleDtos;
                dtos.Add(dto);
            }

            return dtos;
        }

        // GET api/<EjendomController>/5
        [HttpGet("{id}")]
        public EjendomDTO Get(Guid id)
        {
            var model = _getEjendomUseCase.GetEjendom(new GetEjendomRequest { EjendomId = id });
            var dto = new EjendomDTO { Id = model.Id, Adresse = model.Adresse, Postnr = model.Postnr, By = model.By };

            return dto;
        }

        // POST api/<EjendomController>
        [HttpPost]
        public void Post([FromBody] EjendomDTO dto)
        {
            _createEjendomUseCase.CreateEjendom(new CreateEjendomRequest(dto.Adresse, dto.Postnr, dto.By));
        }

        // PUT api/<EjendomController>
        [HttpPut]
        public void Put([FromBody] EjendomDTO dto)
        {
            _updateEjendomUseCase.UpdateEjendom(new UpdateEjendomRequest(dto.Id, dto.Adresse, dto.Postnr, dto.By));
        }

        // DELETE api/<EjendomController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}