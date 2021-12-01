using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejer;
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
        // GET: api/<LejerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LejerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LejerController>
        [HttpPost]
        public void Post([FromBody] LejerDTO dto)
        {
            _createLejerUseCase.CreateLejer(new CreateLejerRequest
                (dto.LejeperiodeStart, dto.LejeperiodeSlut, dto.LejemaalId));
        }

        // PUT api/<LejerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LejerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
