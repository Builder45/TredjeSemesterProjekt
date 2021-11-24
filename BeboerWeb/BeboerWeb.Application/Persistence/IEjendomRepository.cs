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
        public Ejendom GetEjendom(Guid id);

        List<Ejendom> GetEjendomme();

    }
}
