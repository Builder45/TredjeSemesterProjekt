using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagToEjendomViewModel
    {
        public OpslagViewModel Opslag { get; set; }
        public List<EjendomViewModel> Ejendom { get; set; } = new List<EjendomViewModel>();

        public OpslagDTO GetOpslagDTO(EjendomDTO dto)
        {
            return new OpslagDTO()
            {
                Id = Opslag.Id,
                Dato = Opslag.Dato,
                Titel = Opslag.Titel,
                Besked = Opslag.Besked,
                EjendomIds = Opslag.EjendomIds
            };
        }
    }
}
