using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class BrugerViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Husk at skrive et fornavn")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Husk at skrive et efternavn")]
        public string Efternavn { get; set; }

        [Required(ErrorMessage = "Husk at skrive et telefonnummer")]
        [Display(Name = "Tlf. Nr.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "Du skal indtaste et gyldigt telefonnummer")]
        public int Telefonnr { get; set; }

        [Required(ErrorMessage = "Husk at skrive en email")]
        [EmailAddress]
        public string Email { get; set; }
        public Guid BrugerId { get; set; }

        public void AddDataFromDTO(PersonDTO dto)
        {
            Id = dto.Id;
            Fornavn = dto.Fornavn;
            Efternavn = dto.Efternavn;
            Telefonnr = dto.Telefonnr;
            BrugerId = dto.BrugerId;
        }
    }
}