using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LokaleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Du mangler at udfylde adressen:")]
        [Display(Prompt = "Adresse (f.eks: Hybenvej 12)")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Du mangler at angive etagen:")]
        [Display(Prompt = "Etage (f.eks: stue / 2.tv)")]
        public string Etage { get; set; }

        [Required(ErrorMessage = "Du mangler at angive lejemålets areal:")]
        [Display(Prompt = "Areal")]
        public double Areal { get; set; }

        [Required(ErrorMessage = "Du mangler at angive en timepris:")]
        [Display(Prompt = "Timepris")]
        public double Timepris { get; set; }

        [Display(Name = "Køkken")]
        public bool Koekken { get; set; }

        [Display(Name = "Badeværelse")]
        public bool Badevaerelse { get; set; }

        [Required]
        [Display(Prompt = "Tilknyttet Ejendom")]
        public Guid EjendomId { get; set; }

        public void AddDataFromDto(LokaleDTO dto)
        {
            Id = dto.Id;
            Adresse = dto.Adresse;
            Etage = dto.Etage;
            Timepris = dto.Timepris;
            Areal = dto.Areal;
            Koekken = dto.Koekken;
            Badevaerelse = dto.Badevaerelse;
            EjendomId = dto.EjendomId;
        }
    }
}
