using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IEjendomRepository

    {
        void CreateEjendom(Ejendom ejendom);
        public Ejendom GetEjendom(Guid id);
        List<Ejendom> GetEjendomme();
        void UpdateEjendom(Ejendom ejendom);

    }
}
