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
    }
}
