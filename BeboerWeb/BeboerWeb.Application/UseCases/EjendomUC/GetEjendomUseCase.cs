using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.EjendomUC
{
    public class GetEjendomUseCase : IGetEjendomUseCase
    {
        private readonly IEjendomRepository _ejendomRepository;

        public GetEjendomUseCase(IEjendomRepository ejendomRepository)
        {
            _ejendomRepository = ejendomRepository;
        }

        public Ejendom GetEjendom(GetEjendomRequest command)
        {
            return _ejendomRepository.GetEjendom(command.Id);
        }

        public List<Ejendom> GetEjendomme()
        {
            return _ejendomRepository.GetEjendomme();
        }



    }
    
}
