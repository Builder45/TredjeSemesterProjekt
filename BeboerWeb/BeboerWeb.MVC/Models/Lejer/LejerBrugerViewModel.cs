using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejerBrugerViewModel
    {
        public LejerViewModel Lejer { get; set; } = new LejerViewModel();
        public List<BrugerViewModel> Brugere { get; set; } = new List<BrugerViewModel>();

        public LejerDTO GetLejerDTO()
        {
            return new LejerDTO()
            {
                Id = Lejer.Id,
                LejeperiodeStart = Lejer.LejeperiodeStart,
                LejeperiodeSlut = Lejer.LejeperiodeSlut,
                LejemaalId = Lejer.LejemaalId,
                PersonIds = Lejer.PersonIds
            };
        }
    }
}
