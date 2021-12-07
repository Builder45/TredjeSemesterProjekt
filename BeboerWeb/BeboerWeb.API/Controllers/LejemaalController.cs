﻿using BeboerWeb.API.Contract.DTO;
using BeboerWeb.Application.Requests.Lejemaal;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejemaalUC.Interfaces;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using BeboerWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("ByEjendom/{ejendomId}")]
        public IEnumerable<LejemaalDTO> GetLejemaalsByEjendom(Guid ejendomId)
        {
            var model = _getLejemaalUseCase.GetLejemaalsInEjendom(new GetLejemaalRequest{ EjendomId = ejendomId });
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
        public IEnumerable<LejemaalDTO> GetLejemaals()
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

        [HttpGet("{id}")]
        public LejemaalDTO GetLejemaal(Guid id)
        {
            var model = _getLejemaalUseCase.GetLejemaal(new GetLejemaalRequest{ LejemaalId = id });
            var dto = new LejemaalDTO
            {
                Id = model.Id, 
                Adresse = model.Adresse, 
                Etage = model.Etage, 
                Husleje = model.Husleje, 
                Areal = model.Areal, 
                Koekken = model.Koekken, 
                Badevaerelse = model.Badevaerelse, 
                EjendomId = model.Ejendom.Id
            };
            return dto;
        }

        [HttpGet("ByBruger/{brugerId}")]
        public IEnumerable<LejemaalDTO> GetLejemaalsByBruger(Guid brugerId)
        {
            var lejere = _getLejerUseCase.GetLejereByPerson(new GetLejerRequest { BrugerId = brugerId });
            var models = new List<Lejemaal>();
            var lejereInOrderByLejeperiode = lejere.OrderByDescending(l => l.LejeperiodeStart);
            foreach (var item in lejereInOrderByLejeperiode)
            {
                models.Add(_getLejemaalUseCase.GetLejemaalWithLejere(new GetLejemaalRequest { LejemaalId = item.Lejemaal.Id , BrugerId = brugerId}));
            }

            var dtos = new List<LejemaalDTO>();
            foreach (var model in models)
            {
                var dto = new LejemaalDTO
                {
                    Id = model.Id, 
                    Adresse = model.Adresse, 
                    Etage = model.Etage, 
                    Husleje = model.Husleje,
                    Areal = model.Areal, 
                    Koekken = model.Koekken, 
                    Badevaerelse = model.Badevaerelse,
                    EjendomId = model.Ejendom.Id
                };

                var lejerDtos = new List<LejerDTO>();
                model.Lejere.ForEach(e=>lejerDtos.Add(new LejerDTO
                {
                    Id =e.Id,
                    LejeperiodeStart = e.LejeperiodeStart,
                    LejeperiodeSlut = e.LejeperiodeSlut,
                    LejemaalId = e.Lejemaal.Id
                }));
                dto.Lejere = lejerDtos;
                dtos.Add(dto);
            }
            return dtos;
        }
        
        [HttpPost]
        public void PostLejemaal([FromBody] LejemaalDTO dto)
        {
            _createLejemaalUseCase.CreateLejemaal(new CreateLejemaalRequest
                (dto.Adresse, dto.Etage, dto.Husleje, dto.Areal, dto.Koekken, dto.Badevaerelse, dto.EjendomId));
        }

        [HttpPut]
        public void PutLejemaal([FromBody] LejemaalDTO dto)
        {
            _updateLejemaalUseCase.UpdateLejemaal(new UpdateLejemaalRequest
                (dto.Id, dto.Adresse, dto.Etage, dto.Husleje, dto.Areal, dto.Koekken, dto.Badevaerelse, dto.EjendomId));
        }
    }
}
