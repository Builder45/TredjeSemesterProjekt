using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagViewModel
    {
        public Guid Id { get; set; }
        public DateTime Dato { get; set; }

        [Required(ErrorMessage = "Husk at give dit opslag en titel")]
        [StringLength(100)]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Husk at skrive en besked til dit opslag")]
        [StringLength(5000)]
        public string Besked { get; set; }

        [Display(Name = "Ejendomme som er relevante for opslaget:")]
        public List<Guid> EjendomIds { get; set; }

        [Display(Name = "Relevante ejendomme")]
        public List<EjendomViewModel> Ejendomme { get; set; } = new List<EjendomViewModel>();

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
            if (Besked.Length > 30) return Besked.Substring(0, 30) + "...";
            return Besked;
        }

        public string GetDatoString()
        {
            return $"{Dato.Day}/{Dato.Month}/{Dato.Year}";
        }
    }
}
