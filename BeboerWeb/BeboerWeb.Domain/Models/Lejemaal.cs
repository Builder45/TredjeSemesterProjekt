using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lejemaal
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public string Etage { get; set; }
        public double Husleje { get; set; }
        public double Areal { get; set; }
        public bool Koekken { get; set; }
        public bool Badevaerelse { get; set; }

        public Ejendom Ejendom { get; set; }
        public Lejer Lejer { get; set; }

        // Tom constructor vigtig for EF
        public Lejemaal() { }
        public Lejemaal (string adresse, string etage, double husleje, double areal, bool koekken, bool badevaerelse, Ejendom ejendom)
        {
            Adresse = adresse;
            Etage= etage;
            Husleje = husleje; 
            Areal = areal;
            Koekken = koekken;
            Badevaerelse = badevaerelse;
            Ejendom = ejendom;
        }
    }
}
