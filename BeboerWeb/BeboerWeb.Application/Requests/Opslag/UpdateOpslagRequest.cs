namespace BeboerWeb.Application.Requests.Opslag
{
    public class UpdateOpslagRequest
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public List<Guid> EjendomIds { get; set; }

        public UpdateOpslagRequest(Guid id, DateTime dato, string titel, string besked, List<Guid> ejendomIds)
        {
            Id = id;
            Dato = dato;
            Titel = titel;
            Besked = besked;
            EjendomIds = ejendomIds;    
        }
    }
}
