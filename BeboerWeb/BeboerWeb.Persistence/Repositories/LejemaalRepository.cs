using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            return _db.Lejemaal.Include(a => a.Ejendom).First(a=>a.Id == id);
        }

        public List<Lejemaal> GetLejemaalsByEjendom(Guid EjendomId)
        {
            return _db.Ejendom.Include(a=>a.Lejemaal).FirstOrDefault(a=>a.Id==EjendomId)?.Lejemaal??
                   new List<Lejemaal>();
        }

        public List<Lejemaal> GetLejemaals()
        {
            return _db.Lejemaal.Include(a => a.Ejendom).ToList();
        }

        public Lejemaal GetLejemaalWithLejere(Guid lejemaalId, Guid brugerId)
        {
            return _db.Lejemaal
                .Include(a => a.Lejere.Where(f=>f.Personer.Any(p=>p.BrugerId==brugerId)))
                .Include(e=>e.Ejendom)
                .First(a => a.Id == lejemaalId);

        }
        public void CreateLejemaal(Lejemaal lejemaal)
        {
            _db.Add(lejemaal);
            _db.SaveChanges();
        }

        public void UpdateLejemaal(Lejemaal lejemaal)
        {
            if (!lejemaalExists(lejemaal))
                throw new ArgumentException("Lejemaal with given ID does not exist");
            _db.Lejemaal.Update(lejemaal);

            _db.SaveChanges();
        }
        private bool lejemaalExists(Lejemaal lejemaal)
        {
            return _db.Lejemaal.Any(e => e.Id == lejemaal.Id);
        }
    }
}
