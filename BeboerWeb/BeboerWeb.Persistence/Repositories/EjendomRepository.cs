using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            //return _db.Ejendom.FirstOrDefault(e => e.Id == id);
            return _db.Ejendom.Find(id);
        }

        public List<Ejendom> GetEjendomme()
        {
            return _db.Ejendom.ToList();
        }

        public List<Ejendom> GetEjendommeWithLokaler()
        {
            return _db.Ejendom.Include(e => e.Lokaler).ToList();
        }

        public List<Ejendom> GetEjendommeByPerson(Guid personId)
        {
            var person = _db.Person
                .Include(p => p.Lejere)
                .ThenInclude(le => le.Lejemaal)
                .ThenInclude(l => l.Ejendom)
                .First(p => p.Id == personId);

            var ejendomme = new List<Ejendom>();
            foreach (var lejer in person.Lejere)
            {
                if (!ejendomme.Contains(lejer.Lejemaal.Ejendom))
                {
                    ejendomme.Add(lejer.Lejemaal.Ejendom);
                }
            }

            return ejendomme;
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
