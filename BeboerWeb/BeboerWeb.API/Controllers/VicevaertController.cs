using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VicevaertController : ControllerBase
    {
        private readonly ILinkVicevaertUseCase _linkVicevaertUseCase;

        public VicevaertController(ILinkVicevaertUseCase linkVicevaertUseCase)
        {
            _linkVicevaertUseCase = linkVicevaertUseCase;
        }

        // GET: api/<VicevaertController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VicevaertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VicevaertController>
        [HttpPost]
        public void Post([FromBody] VicevaertDTO dto)
        {
            _linkVicevaertUseCase.LinkVicevaert(new LinkVicevaertRequest {BrugerId = dto.BrugerId});
        }

        // DELETE api/<VicevaertController>/5
        [HttpDelete("id")]
        public void Delete(Guid id)
        {
            _linkVicevaertUseCase.UnlinkVicevaert(new LinkVicevaertRequest { BrugerId = id });
        }
    }
}
