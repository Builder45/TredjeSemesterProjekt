using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.Persistence.Repositories
{
    public class OpslagRepository
    {
        private readonly BeboerWebContext _db;
        public OpslagRepository(BeboerWebContext db)
        {
            _db = db;
        }

        public List<Opslag> GetAllOpslag()
        {
            return new List<Opslag>();
        }

        public Opslag GetOpslag(Guid id)
        {
            return _db.Opslag.Find(id);
        }

        public void CreateOpslag(Opslag opslag)
        {
            _db.Add(opslag);
            _db.SaveChanges();
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
    }
}
