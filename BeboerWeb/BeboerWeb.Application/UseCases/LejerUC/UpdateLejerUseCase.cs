using BeboerWeb.Application.Persistence;
using BeboerWeb.Application.Requests.Lejer;
using BeboerWeb.Application.UseCases.LejerUC.Interfaces;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.LejerUC
{
    public class UpdateLejerUseCase : IUpdateLejerUseCase
    {
        private readonly ILejerRepository _lejerRepository;
        private readonly ILejemaalRepository _lejemaalRepository;
        private readonly IPersonRepository _personRepository;

        public UpdateLejerUseCase(ILejerRepository lejerRepository, ILejemaalRepository lejemaalRepository, IPersonRepository personRepository)
        {
            _lejerRepository = lejerRepository;
            _lejemaalRepository = lejemaalRepository;
            _personRepository = personRepository;
        }

        public void UpdateLejer(UpdateLejerRequest command)
        {
            var lejemaal = _lejemaalRepository.GetLejemaal(command.LejemaalId);
            var lejer = new Lejer(command.LejeperiodeStart, command.LejeperiodeSlut, lejemaal);
            lejer.Id = command.Id;

            _lejerRepository.UpdateLejer(lejer);
            _lejerRepository.UnlinkLejerWithPersoner(lejer.Id);

            foreach (var personId in command.PersonIds)
            {
                _lejerRepository.LinkLejerWithPerson(lejer.Id, personId);
            }
        }
    }
}
