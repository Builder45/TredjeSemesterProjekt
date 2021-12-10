namespace BeboerWeb.Domain.Models
{
    public class Opslag
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public List<Ejendom> Ejendomme { get; set; } = new List<Ejendom>();

        // Entity Framework
        public Opslag() { }
        public Opslag(DateTime dato, string titel, string besked)
        {
            Dato = dato;
            Titel = titel;
            Besked = besked;
        }
    }
}
