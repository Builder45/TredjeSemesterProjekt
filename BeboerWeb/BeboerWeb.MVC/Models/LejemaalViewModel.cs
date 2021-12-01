using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejemaalViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Der mangler en adresse!")]
        public string Adresse { get; set; }

        [Required]
        public string Etage { get; set; }

        [Required]
        public double Husleje { get; set; }

        [Required]
        public double Areal { get; set; }

        [Display(Name = "Køkken")]
        [Required(ErrorMessage = "Test")]
        public bool Koekken { get; set; }

        [Display(Name = "Badeværelse")]
        [Required(ErrorMessage = "Test")]
        public bool Badevaerelse { get; set; }

        [Required]
        public Guid EjendomId { get; set; }

        public void AddDataFromDto(LejemaalDTO dto)
        {
            Id = dto.Id;
            Adresse = dto.Adresse;
            Etage = dto.Etage;
            Husleje = dto.Husleje;
            Areal = dto.Areal;
            Koekken = dto.Koekken;
            Badevaerelse = dto.Badevaerelse;
            EjendomId = dto.EjendomId;
        }
    }
}
