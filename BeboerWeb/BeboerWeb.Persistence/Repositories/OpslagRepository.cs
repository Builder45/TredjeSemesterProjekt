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
            return _db.Opslag.ToList();
        }

        public Opslag GetOpslag(Guid id)
        {
            return _db.Opslag.Find(id);
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
