namespace BeboerWeb.MVC.Models
{
    public class UserPolicyViewModel
    {
        public Guid BrugerId { get; set; }
        public string Email { get; set; }
        public bool IsVV { get; set; } = false;
        public bool IsBA { get; set; } = false;
    }
}
