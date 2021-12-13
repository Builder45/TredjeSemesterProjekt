using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagEjendommeViewModel
    {
        public OpslagViewModel Opslag { get; set; } = new OpslagViewModel();
        public List<EjendomViewModel> Ejendomme { get; set; } = new List<EjendomViewModel>();

        public OpslagDTO GetOpslagDTO()
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
