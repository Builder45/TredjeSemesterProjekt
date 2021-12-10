namespace BeboerWeb.API.Contract.DTO
{
    public class OpslagDTO
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public List<Guid> EjendomIds { get; set; } = new List<Guid>();
        public List<EjendomDTO> Ejendomme { get; set; } = new List<EjendomDTO>();
    }
}
