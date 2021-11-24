using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.UseCases.EjendomUC;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjendomController : ControllerBase
    {
        private readonly IGetEjendomUseCase _getEjendomUseCase;

        public EjendomController(IGetEjendomUseCase getEjendomUseCase)
        {
            _getEjendomUseCase = getEjendomUseCase;
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

        // GET api/<EjendomController>/5
        [HttpGet("{id}")]
        public EjendomDTO Get(Guid ejendomId)
        {
            var model = _getEjendomUseCase.GetEjendom(new GetEjendomRequest
            { Id = ejendomId });
            var dto = new EjendomDTO { Id = model.Id, Adresse = model.Adresse, Postnr = model.Postnr, By = model.By };

            return dto;
        }

        // POST api/<EjendomController>
        [HttpPost]
        public void Post([FromBody] EjendomDTO dto)
        {
        }

        // PUT api/<EjendomController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] EjendomDTO dto)
        {
        }

        // DELETE api/<EjendomController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}