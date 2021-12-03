namespace BeboerWeb.MVC.Models
{
    public class LejerBrugerViewModel
    {
        public LejerViewModel Lejer { get; set; } = new LejerViewModel();
        public List<BrugerViewModel> Brugere { get; set; }
    }
}
