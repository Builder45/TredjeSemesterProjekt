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

        public void LinkVicevaert(Vicevaert vicevaert)
        {
            _db.Vicevaert.Add(vicevaert);
            _db.SaveChanges();
        }

        public void UnlinkVicevaert(Vicevaert vicevaert)
        {
            _db.Vicevaert.Remove(vicevaert);
            _db.SaveChanges();
        }
    }
}
