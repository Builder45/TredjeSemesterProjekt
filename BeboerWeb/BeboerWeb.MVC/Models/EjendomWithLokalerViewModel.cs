using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class EjendomWithLokalerViewModel
    {
        public EjendomViewModel Ejendom { get; set; } = new EjendomViewModel();
        public List<LokaleViewModel> Lokaler { get; set; } = new List<LokaleViewModel>();
        public void AddDataFromDTO(EjendomDTO dto)
        {
            Ejendom.AddDataFromDto(dto);
            foreach (var lokaleDto in dto.Lokaler)
            {
                var lokale = new LokaleViewModel();
                lokale.AddDataFromDto(lokaleDto);
                Lokaler.Add(lokale);
            }
        }
    }
}
