using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Vicevaert
    {
        public Guid Id { get; set; }

        public List<Ejendom> Ejendomme { get; set; }
        public Person Person { get; set; }

        // Tom constructor vigtig for EF
        public Vicevaert() { }
    }
}
