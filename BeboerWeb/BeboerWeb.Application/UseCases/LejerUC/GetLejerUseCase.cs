using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejerUC
{
    public class GetLejerUseCase : IGetLejerUseCase
    {
        private readonly ILejerRepository _repository;
        public GetLejerUseCase(ILejerRepository repository)
        {
            _repository = repository;
        }
        public Lejer GetLejer(GetLejerRequest command)
        {
            return _repository.GetLejer(command.LejerId);
        }

        public List<Lejer> GetLejereByPerson(GetLejerRequest command)
        {
            return _repository.GetLejereByPerson(command.BrugerId);
        }

        public List<Lejer> GetLejere()
        {
            throw new NotImplementedException();
        }

        public List<Lejer> GetLejereByEjendom(GetLejerRequest command)
        {
            return _repository.GetLejereByEjendom(command.EjendomId);
        }

        public List<Lejer> GetLejereByLejemaal(GetLejerRequest command)
        {
            return _repository.GetLejereByLejemaal(command.LejemaalId);
        }

        

    }
}
