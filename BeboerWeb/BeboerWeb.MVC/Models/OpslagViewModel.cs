using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagViewModel
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public List<Guid> EjendomIds { get; set; }

        public void AddDataFromDto(OpslagDTO dto)
        {
            Id = dto.Id;
            Dato = dto.Dato;
            Titel = dto.Titel;
            Besked = dto.Besked;
            EjendomIds = dto.EjendomIds;
        }

        public string GetBeskedPreview()
        {
            return Besked.Substring(0,30)+"...";
        }
    }
}
