using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class EjendomViewModel
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
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
