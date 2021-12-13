namespace BeboerWeb.MVC.Models
{
    public class BrugerSearchViewModel
    {
        public List<BrugerViewModel> Brugere { get; set; } = new List<BrugerViewModel>();
        public string SearchTerm { get; set; }
    }
}
