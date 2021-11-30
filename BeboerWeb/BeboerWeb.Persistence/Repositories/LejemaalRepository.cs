using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Persistence.Repositories
{
    public class LejemaalRepository : ILejemaalRepository
    {
        private readonly BeboerWebContext _db;

        public LejemaalRepository(BeboerWebContext db)
        {
            _db = db;
        }


        public Lejemaal GetLejemaal(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Lejemaal> GetLejemaal()
        {
            throw new NotImplementedException();
        }

        public void CreateLejemaal(Lejemaal lejemaal)
        {
            _db.Add(lejemaal);
            _db.SaveChanges();
        }

        public void UpdateLejemaal(Lejemaal lejemaal)
        {
            throw new NotImplementedException();
        }
    }
}
