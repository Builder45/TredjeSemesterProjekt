using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.Persistence.Repositories
{
    public class LejerRepository : ILejerRepository
    {
        private readonly BeboerWebContext _db;

        public LejerRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public Lejer GetLejer(Guid id)
        {
            return _db.Lejer.Include(l => l.Lejemaal).First(l => l.Id == id);
        }

        public List<Lejer> GetLejere()
        {
            return _db.Lejer.Include(a => a.Lejemaal).ToList();
        }

        public List<Lejer> GetLejereByLejemaal(Guid lejemaalId)
        {
            return _db.Lejer.Include(a => a.Lejemaal).Where(l => l.Lejemaal.Id == lejemaalId).ToList();
        }
        public List<Lejer> GetLejereByEjendom(Guid ejendomId)
        {
            return _db.Lejer.Include(a => a.Lejemaal).Where(l => l.Lejemaal.Ejendom.Id == ejendomId).ToList();
        }
        public Guid CreateLejer(Lejer lejer)
        {
            _db.Add(lejer);
            _db.SaveChanges();

            return lejer.Id;
        }
        public void LinkLejerWithPerson(Guid lejerId, Guid personId)
        {
            var lejer = _db.Lejer.First(l => l.Id == lejerId);
            var person = _db.Person.First(p => p.Id == personId);
            lejer.Personer.Add(person);
            _db.Update(lejer);
            _db.SaveChanges();
        }

        public void UpdateLejer(Lejer lejer)
        {
            _db.Update(lejer);
            _db.SaveChanges();
        }
    }
}
