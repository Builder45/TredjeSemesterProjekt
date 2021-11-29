using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class BrugerViewModel
    {
        public Guid Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Telefonnr { get; set; }
        public Guid BrugerId { get; set; }
        public string Email { get; set; }
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