using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Application.UseCases.LejerUC;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
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
        private readonly IGetLejemaalUseCase _getLejemaalUseCase;
        private readonly IUpdateLejemaalUseCase _updateLejemaalUseCase;
        private readonly IGetLejerUseCase _getLejerUseCase;
        public LejemaalController(ICreateLejemaalUseCase createLejemaalUseCase, IGetLejemaalUseCase getLejemaalUseCase, IUpdateLejemaalUseCase updateLejemaalUseCase, IGetLejerUseCase getLejerUseCase)
        {
            _createLejemaalUseCase = createLejemaalUseCase;
            _getLejemaalUseCase = getLejemaalUseCase;
            _updateLejemaalUseCase = updateLejemaalUseCase;
            _getLejerUseCase = getLejerUseCase;

        }


        // GET: api/<LejemaalController>
        [HttpGet("Ejendom/{ejendomId}")]
        public IEnumerable<LejemaalDTO> GetAllByEjendom(Guid ejendomId)
        {
            var model = _getLejemaalUseCase.GetLejemaalsInEjendom(new GetLejemaalRequest{EjendomId = ejendomId});
            var dto = new List<LejemaalDTO>();
            model.ForEach(a => dto.Add(new LejemaalDTO
            {
                Id = a.Id,
                Adresse = a.Adresse,
                Etage = a.Etage,
                Husleje = a.Husleje,
                Areal = a.Areal,
                Koekken = a.Koekken,
                Badevaerelse = a.Badevaerelse,
                EjendomId = a.Ejendom.Id
            }));
            return dto;
        }

        [HttpGet]
        public IEnumerable<LejemaalDTO> GetAll()
        {
            var model = _getLejemaalUseCase.GetLejemaals();
            var dto = new List<LejemaalDTO>();
            model.ForEach(a => dto.Add(new LejemaalDTO
            {
                Id = a.Id,
                Adresse = a.Adresse,
                Etage = a.Etage,
                Husleje = a.Husleje,
                Areal = a.Areal,
                Koekken = a.Koekken,
                Badevaerelse = a.Badevaerelse,
                EjendomId = a.Ejendom.Id
            }));
            return dto;
        }

        // GET api/<LejemaalController>/5
        [HttpGet("{id}")]
        public LejemaalDTO Get(Guid id)
        {
            var model = _getLejemaalUseCase.GetLejemaal(new GetLejemaalRequest
                {LejemaalId = id });
            var dto = new LejemaalDTO
            {
                Id = model.Id, Adresse = model.Adresse, Etage = model.Etage, Husleje = model.Husleje, Areal = model.Areal, Koekken = model.Koekken, Badevaerelse = model.Badevaerelse, EjendomId = model.Ejendom.Id
            };
            return dto;
        }

        [HttpGet("Lejer/{id}")]
        public IEnumerable<LejemaalDTO> GetLejerLejemaal(Guid id)
        {
            var lejer = _getLejerUseCase.GetLejereByPerson(new GetLejerRequest { BrugerId = id });
            var model = new List<Lejemaal>();
            //var lejer = _getLejerUseCase.GetLejer(new GetLejerRequest {LejerId = id});
            foreach (var item in lejer)
            {
                model.Add(_getLejemaalUseCase.GetLejemaal(new GetLejemaalRequest { LejemaalId = item.Lejemaal.Id }));
            }

            var dtos = new List<LejemaalDTO>();
            model.ForEach(a => dtos.Add(new LejemaalDTO
            {
                Id = a.Id,
                Adresse = a.Adresse,
                Etage = a.Etage,
                Husleje = a.Husleje,
                Areal = a.Areal,
                Koekken = a.Koekken,
                Badevaerelse = a.Badevaerelse,
                EjendomId = a.Ejendom.Id
            }));
            return dtos;
        }

        // POST api/<LejemaalController>
        [HttpPost]
        public void Post([FromBody] LejemaalDTO dto)
        {
            _createLejemaalUseCase.CreateLejemaal(new CreateLejemaalRequest
                (dto.Adresse,dto.Etage,dto.Husleje,dto.Areal,dto.Koekken,dto.Badevaerelse,dto.EjendomId));
        }

        // PUT api/<LejemaalController>
        [HttpPut]
        public void Put([FromBody] LejemaalDTO dto)
        {
            _updateLejemaalUseCase.UpdateLejemaal(new UpdateLejemaalRequest(dto.Id, dto.Adresse, dto.Etage, dto.Husleje, dto.Areal, dto.Koekken, dto.Badevaerelse, dto.EjendomId));
        }

        
    }
}
