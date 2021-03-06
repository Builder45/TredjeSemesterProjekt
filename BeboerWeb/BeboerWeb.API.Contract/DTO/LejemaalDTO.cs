using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class LejemaalDTO
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
        public List<LejerDTO> Lejere { get; set; }
    }
}
