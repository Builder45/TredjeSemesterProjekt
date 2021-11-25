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

        public void CreateEjendom(Ejendom ejendom)
        {
            _db.Add(ejendom);
            _db.SaveChanges();
        }

        public Ejendom GetEjendom(Guid id)
        {
            return _db.Ejendom.FirstOrDefault(e => e.Id == id);
        }

        public List<Ejendom> GetEjendomme()
        {
            return _db.Ejendom.ToList();
        }

        public void UpdateEjendom(Ejendom ejendom)
        {
            if (!ejendomExists(ejendom))
                throw new ArgumentException("Ejendom with given ID does not exist");

            _db.Ejendom.Update(ejendom);
            _db.SaveChanges();
        }

        private bool ejendomExists(Ejendom ejendom)
        {
            return _db.Ejendom.Any(e => e.Id == ejendom.Id);
        }
    }
}
