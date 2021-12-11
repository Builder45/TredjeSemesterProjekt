using BeboerWeb.API.Contract.DTO;
using System.ComponentModel.DataAnnotations;

namespace BeboerWeb.MVC.Models
{
    public class EjendomViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Husk at udfylde adressen")]
        [StringLength(100)]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Husk at udfylde postnummeret")]
        [Range(1000, 9999, ErrorMessage = "Angiv et gyldigt postnummer på fire cifre")]
        public int Postnr { get; set; }

        [Required(ErrorMessage = "Husk at udfylde bynavnet")]
        [StringLength(100)]
        public string By { get; set; }

        public void AddDataFromDto(EjendomDTO dto)
        {
            Id = dto.Id;
            Adresse = dto.Adresse;
            Postnr = dto.Postnr;
            By = dto.By;
        }
    }
}
