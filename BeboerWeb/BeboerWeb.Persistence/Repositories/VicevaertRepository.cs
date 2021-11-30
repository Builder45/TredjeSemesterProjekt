using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Persistence.Repositories
{
    public class VicevaertRepository : IVicevaertRepository
    {
        private readonly BeboerWebContext _db;

        public VicevaertRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public Vicevaert GetVicevaertByPerson(Guid personId)
        {
            return _db.Vicevaert.First(v => v.Person.Id == personId);
        }

        public void LinkVicevaert(Vicevaert vicevaert)
        {
            _db.Vicevaert.Add(vicevaert);
            _db.SaveChanges();
        }

        public void UnlinkVicevaert(Vicevaert vicevaert)
        {
            var vicevaertToDelete = GetVicevaertByPerson(vicevaert.Person.Id);
            _db.Vicevaert.Remove(vicevaertToDelete);
            _db.SaveChanges();
        }

        public void AddVicevaertToEjendom(Guid personId, Guid ejendomId)
        {
            var ejendom = _db.Ejendom.First(e => e.Id == ejendomId);
            var vicevaert = GetVicevaertByPerson(personId);

            ejendom.Vicevaerter.Add(vicevaert);
            _db.Ejendom.Update(ejendom);
            _db.SaveChanges();
        }
    }
}
