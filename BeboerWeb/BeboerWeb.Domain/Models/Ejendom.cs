using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Ejendom
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }

        public List<Vicevaert> Vicevaerter { get; set; }
        public List<Bygning> Bygninger { get; set; }
        public Afdeling Afdeling { get; set; }

    }
}
