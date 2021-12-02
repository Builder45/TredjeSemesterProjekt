using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lokale
{
    public class UpdateLokaleRequest
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public string Etage { get; set; }
        public double Areal { get; set; }
        public double Timepris { get; set; }
        public bool Koekken { get; set; }
        public bool Badevaerelse { get; set; }
        public Guid EjendomId { get; set; }

        public UpdateLokaleRequest(Guid id, string adresse, string etage, double areal, double timepris,
            bool koekken, bool badevaerelse, Guid ejendomId)
        {
            Id = id;
            Adresse = adresse;
            Etage = etage;
            Areal = areal;
            Timepris = timepris;
            Koekken = koekken;
            Badevaerelse = badevaerelse;
            EjendomId = ejendomId;
        }
    }
}
