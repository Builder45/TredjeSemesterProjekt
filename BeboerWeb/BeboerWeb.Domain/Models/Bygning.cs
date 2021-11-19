using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Bygning
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }
        
        public List<Lejemaal> Lejemaal { get; set; }
        public List <Lokale> Lokaler { get; set; }

        public Ejendom Ejendom { get; set; }
    }
}
