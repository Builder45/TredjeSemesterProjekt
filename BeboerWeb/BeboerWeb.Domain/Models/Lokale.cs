using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lokale
    {
        public Guid Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Etage { get; set; }
        public double Timepris { get; set; }
        public double Areal { get; set; }
        public bool Koekken { get; set; }
        public bool Badevaerelse { get; set; }

        public List<Booking> Bookinger { get; set; }
        public Ejendom Ejendom { get; set; }

        // Tom constructor vigtig for EF
        public Lokale() { }

        public Lokale(string navn, string adresse, string etage, double timepris, double areal, bool koekken, bool badevaerelse, Ejendom ejendom)
        {
            Navn = navn;
            Adresse = adresse;
            Etage = etage;
            Timepris = timepris;
            Areal = areal;
            Koekken = koekken;
            Badevaerelse = badevaerelse;
            Ejendom = ejendom;
        }
    }
}
