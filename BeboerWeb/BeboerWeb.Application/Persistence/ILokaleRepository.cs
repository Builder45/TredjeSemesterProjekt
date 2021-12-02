using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface ILokaleRepository
    {
        public Lokale GetLokale(Guid id);

        public List<Lokale> GetLokalerByEjendom(Guid EjendomId);

        public List<Lokale> GetLokaler();

        void CreateLokale(Lokale lokale);

        void UpdateLokale(Lokale lokale);
    }
}
