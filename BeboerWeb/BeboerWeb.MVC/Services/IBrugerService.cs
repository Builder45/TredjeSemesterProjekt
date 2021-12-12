using Microsoft.AspNetCore.Identity;

namespace BeboerWeb.MVC.Services
{
    public interface IBrugerService
    {
        Task<IdentityUser> GetBruger(Guid brugerId);
        Task<IdentityUser> GetBrugerByBrugernavn(string brugernavn);
        Task<List<IdentityUser>> GetBrugere();
        Task<bool> BrugerHasClaim(Guid brugerId, string claim);
        Task AddClaimToBruger(Guid brugerId, string claim);
        Task RemoveClaimFromBruger(Guid brugerId, string claim);
    }
}
