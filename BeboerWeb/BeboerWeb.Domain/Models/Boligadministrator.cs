using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Boligadministrator
    {
        public Guid Id { get; set; }

        public List<Afdeling> Afdelinger { get; set; }
        public Person Person { get; set; }
    }
}
