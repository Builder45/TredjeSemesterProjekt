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
    public class CreateLejerUseCase : ICreateLejerUseCase
    {
        private readonly ILejerRepository _lejerRepository;
        private readonly ILejemaalRepository _lejemaalRepository;

        public CreateLejerUseCase(ILejerRepository lejerRepository, ILejemaalRepository lejemaalRepository)
        {
            _lejerRepository = lejerRepository;
            _lejemaalRepository = lejemaalRepository;
        }

        public void CreateLejer(CreateLejerRequest command)
        {
            var lejemaal = _lejemaalRepository.GetLejemaal(command.LejemaalId);
            var lejer = new Lejer(command.LejeperiodeStart, command.LejeperiodeSlut, lejemaal);
            _lejerRepository.CreateLejer(lejer);
        }
    }
}
