namespace BeboerWeb.MVC.Models
{
    public class UserPolicyViewModel
    {
        public string Email { get; set; }
        public Guid BrugerId { get; set; }
        public bool WasVV { get; set; } = false;
        public bool IsVV { get; set; } = false;
    }
}
