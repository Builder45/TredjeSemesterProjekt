using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class OpslagToEjendomViewModel
    {
        public OpslagViewModel Opslag { get; set; }
        public List<EjendomViewModel> Ejendom { get; set; } = new List<EjendomViewModel>();

        public OpslagDTO GetOpslagDtoDTO()
        {
            return new OpslagDTO()
            {
                Id = Opslag.Id,
                Date = Opslag.Date,
                Besked = Opslag.Besked,
                EjendomId = Opslag.EjendomId
            };
        }
    }
}
