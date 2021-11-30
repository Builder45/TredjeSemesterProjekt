using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LejemaalController : ControllerBase
    {
        private readonly ICreateLejemaalUseCase _createLejemaalUseCase;
        // private readonly IGetLejemaalUseCase _getLejemaalUseCase;
        // private readonly IUpdateLejemaalUseCase _updateLejemaalUseCase;

        public LejemaalController(ICreateLejemaalUseCase createLejemaalUseCase) //IGetLejemaalUseCase getLejemaalUseCase, IUpdateLejemaalUseCase updateLejemaalUseCase)
        {
            _createLejemaalUseCase = createLejemaalUseCase;

            //_getLejemaalUseCase = getLejemaalUseCase;
            //_updateLejemaalUseCase = updateLejemaalUseCase;

        }


        // GET: api/<LejemaalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LejemaalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LejemaalController>
        [HttpPost]
        public void Post([FromBody] LejemaalDTO dto)
        {
            _createLejemaalUseCase.CreateLejemaal(new CreateLejemaalRequest
                (dto.Adresse,dto.Etage,dto.Husleje,dto.Areal,dto.Koekken,dto.Badevaerelse,dto.EjendomId));
        }

        // PUT api/<LejemaalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
