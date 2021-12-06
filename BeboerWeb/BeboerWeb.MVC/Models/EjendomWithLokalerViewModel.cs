using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class EjendomWithLokalerViewModel
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }
        public List<LokaleViewModel> Lokaler { get; set; } = new List<LokaleViewModel>();
        public void AddDataFromDTO(EjendomDTO dto)
        {
            Id = dto.Id;
            Adresse = dto.Adresse;
            Postnr = dto.Postnr;
            By = dto.By;
            foreach (var lokaleDto in dto.Lokaler)
            {
                var lokale = new LokaleViewModel();
                lokale.AddDataFromDto(lokaleDto);
                Lokaler.Add(lokale);
            }
        }
    }
}
