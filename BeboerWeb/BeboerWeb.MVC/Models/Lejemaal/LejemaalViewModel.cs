using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejemaalViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Husk at udfylde adressen:")]
        [StringLength(100)]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Husk at angive etagen:")]
        [StringLength(10)]
        public string Etage { get; set; }

        [Required(ErrorMessage = "Husk at angive arealet:")]
        [Range(0, 10000, ErrorMessage = "Angiv et realistisk areal")]
        public double Areal { get; set; }

        [Required(ErrorMessage = "Husk at angive en husleje:")]
        [Range(0, 10000000, ErrorMessage = "Husk at angive en husleje:")]
        public double Husleje { get; set; }

        [Display(Name = "Køkken")]
        public bool Koekken { get; set; }

        [Display(Name = "Badeværelse")]
        public bool Badevaerelse { get; set; }

        [Required]
        [Display(Name = "Tilhørende ejendom")]
        public Guid EjendomId { get; set; }

        public byte[] RowVersion { get; set; }

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
            RowVersion = dto.RowVersion;
        }
    }
}
