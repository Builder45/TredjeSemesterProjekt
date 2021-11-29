using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
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
            return _ejendomRepository.GetEjendom(command.EjendomId);
        }

        public List<Ejendom> GetEjendomme()
        {
            return _ejendomRepository.GetEjendomme();
        }



    }
    
}
