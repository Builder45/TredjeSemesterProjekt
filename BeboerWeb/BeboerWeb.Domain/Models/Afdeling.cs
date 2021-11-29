using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Afdeling
    {
        public Guid Id { get; set; }
        public string Navn { get; set; }
        
        public List<Boligadministrator> Boligadministratorer { get; set; }
        public List<Ejendom> Ejendomme { get; set; }

        // Tom constructor vigtig for EF
        public Afdeling() { }
    }

    
}
