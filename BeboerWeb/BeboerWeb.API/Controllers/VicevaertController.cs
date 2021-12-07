using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VicevaertController : ControllerBase
    {
        private readonly ILinkVicevaertUseCase _linkVicevaertUseCase;
        private readonly IAddVicevaertToEjendomUseCase _addVicevaertToEjendomUseCase;
        private readonly IGetVicevaertUseCase _getVicevaertUseCase;

        public VicevaertController(ILinkVicevaertUseCase linkVicevaertUseCase, IAddVicevaertToEjendomUseCase addVicevaertToEjendomUseCase, IGetVicevaertUseCase getVicevaertUseCase)
        {
            _linkVicevaertUseCase = linkVicevaertUseCase;
            _addVicevaertToEjendomUseCase = addVicevaertToEjendomUseCase;
            _getVicevaertUseCase = getVicevaertUseCase;
        }

        [HttpGet("ByBruger/{brugerId}")]
        public IEnumerable<string> GetVicevaerterByBruger(Guid brugerId)
        {
            var vicevaerter = _getVicevaertUseCase.GetRelevantVicevaerterByBruger(new GetVicevaertRequest {BrugerId = brugerId});
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string GetVicevaert(int id)
        {
            return "value";
        }

        [HttpPost]
        public void PostVicevaert([FromBody] VicevaertDTO dto)
        {
            _linkVicevaertUseCase.LinkVicevaert(new LinkVicevaertRequest {BrugerId = dto.BrugerId});
        }

        [HttpPost("ToEjendom")]
        public void AddVicevaertToEjendom([FromBody] ServiceOversigtDTO dto)
        {
            _addVicevaertToEjendomUseCase.AddVicevaertToEjendom(new AddVicevaertToEjendomRequest {EjendomId = dto.EjendomId, PersonId = dto.PersonId});
        }

        [HttpDelete("{id}")]
        public void DeleteVicevaert(Guid id)
        {
            _linkVicevaertUseCase.UnlinkVicevaert(new LinkVicevaertRequest { BrugerId = id });
        }
    }
}
