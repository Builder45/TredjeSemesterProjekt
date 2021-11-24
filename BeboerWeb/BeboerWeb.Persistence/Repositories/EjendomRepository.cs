using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Persistence.Repositories
{
    public class EjendomRepository : IEjendomRepository
    {
        private readonly BeboerWebContext _db;

        public EjendomRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public Ejendom GetEjendom(Guid id)
        {
            return _db.Ejendom.FirstOrDefault(e => e.Id == id);
        }

        public List<Ejendom> GetEjendomme()
        {
            return _db.Ejendom.ToList();
        }
    }
}
