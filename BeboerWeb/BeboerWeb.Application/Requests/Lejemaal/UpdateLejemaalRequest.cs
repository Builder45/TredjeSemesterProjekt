using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lejemaal
{
    public class UpdateLejemaalRequest
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public string Etage { get; set; }
        public double Husleje { get; set; }
        public double Areal { get; set; }
        public bool Koekken { get; set; }
        public bool Badevaerelse { get; set; }
        public byte[] RowVersion { get; set; }

        public Guid EjendomId { get; set; }

        public UpdateLejemaalRequest(Guid id, string adresse, string etage, double husleje, double areal, bool koekken, bool badevaerelse, Guid ejendomId, byte[] rowVersion)
        {
            Id = id;
            Adresse = adresse;
            Etage = etage;
            Husleje = husleje;
            Areal = areal;
            Koekken = koekken;
            Badevaerelse = badevaerelse;
            EjendomId = ejendomId;
            RowVersion = rowVersion;
        }
        
    }
}
