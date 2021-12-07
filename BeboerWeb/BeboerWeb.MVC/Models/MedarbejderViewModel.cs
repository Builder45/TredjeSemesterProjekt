using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class MedarbejderViewModel
    {
        public BrugerViewModel Bruger { get; set; }

        public string Stilling { get; set; }
    }
}
