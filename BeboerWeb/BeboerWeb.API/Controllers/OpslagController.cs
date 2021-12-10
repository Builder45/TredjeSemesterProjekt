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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
