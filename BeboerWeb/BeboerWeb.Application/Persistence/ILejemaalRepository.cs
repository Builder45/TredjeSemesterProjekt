using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Persistence
{
    public interface ILejemaalRepository
    {
        public Lejemaal GetLejemaal(Guid id);

        public Lejemaal GetLejemaalWithLejere(Guid lejemaalId, Guid brugerId);

        public List<Lejemaal> GetLejemaalByBruger(Guid brugerId);

        public List<Lejemaal> GetLejemaalsByEjendom(Guid EjendomId);

        public List<Lejemaal> GetLejemaals();

        void CreateLejemaal(Lejemaal lejemaal);

        void UpdateLejemaal(Lejemaal lejemaal);

    }
}
