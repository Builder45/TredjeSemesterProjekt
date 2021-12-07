using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class MedarbejderViewModel
    {
        public BrugerViewModel Bruger { get; set; }

        public string stilling { get; set; }
    }
}
