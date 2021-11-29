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

        public List<Lejemaal> GetLejemaal();

        void CreateLejemaal(Lejemaal lejemaal);

        void UpdateLejemaal(Lejemaal lejemaal);

    }
}
