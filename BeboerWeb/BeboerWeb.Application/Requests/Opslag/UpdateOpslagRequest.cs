namespace BeboerWeb.Application.Requests.Opslag
{
    public class UpdateOpslagRequest
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public List<Guid> EjendomIds { get; set; }
    }
}
