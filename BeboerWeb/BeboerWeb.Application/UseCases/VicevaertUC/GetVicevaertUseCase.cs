using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Vicevaert;
using BeboerWeb.Application.UseCases.VicevaertUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.VicevaertUC
{
    public class GetVicevaertUseCase : IGetVicevaertUseCase
    {
        private readonly IVicevaertRepository _vicevaertRepository;
        private readonly ILejerRepository _lejerRepository;
        private readonly IPersonRepository _personRepository;

        public GetVicevaertUseCase(IVicevaertRepository vicevaertRepository, ILejerRepository lejerRepository, IPersonRepository personRepository)
        {
            _vicevaertRepository = vicevaertRepository;
            _lejerRepository = lejerRepository;
            _personRepository = personRepository;
        }

        public List<Vicevaert> GetRelevantVicevaerterByBruger(GetVicevaertRequest command)
        {
            var person = _personRepository.GetPersonByUser(command.BrugerId);
            var lejere = _lejerRepository.GetLejereByPerson(person.Id);

            var vicevaerter = new List<Vicevaert>();
            var idList = new List<Guid>();

            foreach (var lejer in lejere)
            {
                var ejendomId = lejer.Lejemaal.Ejendom.Id;
                if (!idList.Contains(ejendomId))
                {
                    var vicevaerterByEjendom = _vicevaertRepository.GetVicevaerterByEjendom(ejendomId);
                    foreach (var vicevaert in vicevaerterByEjendom)
                    {
                        if (!vicevaerter.Contains(vicevaert)) vicevaerter.Add(vicevaert);
                    }
                    idList.Add(ejendomId);
                }
            }
            return vicevaerter;
        }
    }
}
