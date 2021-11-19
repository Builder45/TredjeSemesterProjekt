using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lokale
    {
        public int Id { get; set; }
        public string Etage { get; set; }
        public double Timepris { get; set; }
        public double Areal { get; set; }
    }
}
