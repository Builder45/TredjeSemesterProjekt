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
    public class LokaleRepository : ILokaleRepository 
    {
        private readonly BeboerWebContext _db;

        public LokaleRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public Lokale GetLokale(Guid id)
        {
            return _db.Lokale.Include(a => a.Ejendom).First(a => a.Id == id);
        }

        public List<Lokale> GetLokalerByEjendom(Guid EjendomId)
        {
            return _db.Ejendom.Include(a => a.Lokaler).FirstOrDefault(a => a.Id == EjendomId)?.Lokaler ?? new List<Lokale>();
        }

        public List<Lokale> GetLokaler()
        {
            return _db.Lokale.Include(a => a.Ejendom).ToList();
        }

        public void CreateLokale(Lokale lokale)
        {
            _db.Add(lokale);
            _db.SaveChanges();
        }

        public void UpdateLokale(Lokale lokale)
        {
            if (!lokaleExists(lokale))
                throw new ArgumentException("Lokale with given ID does not exist");
            _db.Lokale.Update(lokale);
            _db.SaveChanges();
        }

        public bool lokaleExists(Lokale lokale)
        {
            return _db.Lokale.Any(e => e.Id == lokale.Id);
        }
    }
}
