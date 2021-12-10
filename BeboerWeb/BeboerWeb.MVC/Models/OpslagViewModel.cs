using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Besked { get; set; }
        public Guid EjendomId { get; set; }

        public void AddDataFromDto(OpslagDTO dto)
        {
            Id = dto.Id;
            Date = dto.Date;
            Besked = dto.Besked;
        }
    }
}
