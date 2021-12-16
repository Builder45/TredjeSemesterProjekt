using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.Persistence.Repositories
{
    public class OpslagRepository : IOpslagRepository
    {
        private readonly BeboerWebContext _db;

        public OpslagRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public List<Opslag> GetAllOpslag()
        {
            return _db.Opslag.Include(o => o.Ejendomme)
                .ToList();
        }

        public List<Opslag> GetOpslagByEjendomme(List<Ejendom> ejendomme)
        {
            var relevantOpslag = new List<Opslag>();
            foreach (var ejendom in ejendomme)
            {
                var ejendomOpslag = _db.Opslag
                    .Include(o => o.Ejendomme)
                    .Where(o => o.Ejendomme.Contains(ejendom));
                foreach (var opslag in ejendomOpslag)
                {
                    if (!relevantOpslag.Contains(opslag))
                    {
                        relevantOpslag.Add(opslag);
                    }
                }
            }

            return relevantOpslag;
        }

        public Opslag GetOpslag(Guid id)
        {
            return _db.Opslag
                .Include(o => o.Ejendomme)
                .First(o => o.Id == id);
        }

        public Guid CreateOpslag(Opslag opslag)
        {
            _db.Add(opslag);
            _db.SaveChanges();

            return opslag.Id;
        }
        public void UpdateOpslag(Opslag opslag)
        {
            _db.Update(opslag);
            _db.SaveChanges();
        }

        public void DeleteOpslag(Opslag opslag)
        {
            _db.Remove(opslag);
            _db.SaveChanges();
        }

        public void LinkOpslagWithEjendom(Guid opslagsId, Guid ejendomId)
        {
            var opslag = _db.Opslag.First(o => o.Id == opslagsId);
            var ejendom = _db.Ejendom.First(e => e.Id == ejendomId);
            opslag.Ejendomme.Add(ejendom);
            _db.Update(opslag);
            _db.SaveChanges();
        }

        public void UnlinkOpslagWithEjendomme(Guid opslagsId)
        {
            var opslag = _db.Opslag
                .Include(l => l.Ejendomme)
                .First(l => l.Id == opslagsId);
            opslag.Ejendomme.Clear();

            _db.Update(opslag);
            _db.SaveChanges();
        }
    }
}
