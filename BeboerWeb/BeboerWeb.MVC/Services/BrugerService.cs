using System.Security.Claims;
using BeboerWeb.MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Services
{
    public class BrugerService : IBrugerService
    {
        //private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;

        public BrugerService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager; 
        }

        public async Task<IdentityUser> GetBruger(Guid brugerId) =>
            await _userManager.FindByIdAsync(brugerId.ToString());

        public async Task<IdentityUser> GetBrugerByBrugernavn(string brugernavn) =>
            await _userManager.FindByNameAsync(brugernavn); 

        public async Task<List<IdentityUser>> GetBrugere() =>
            await _userManager.Users.ToListAsync();

        public async Task<bool> BrugerHasClaim(Guid brugerId, string claim)
        {
            var bruger = await GetBruger(brugerId);
            var list = await _userManager.GetUsersForClaimAsync(new Claim(claim, "Yes"));

            return list.Contains(bruger);
        }

        public async Task AddClaimToBruger(Guid brugerId, string claim)
        {
            var bruger = await GetBruger(brugerId);
            await _userManager.AddClaimAsync(bruger, new Claim(claim, "Yes"));
        }

        public async Task RemoveClaimFromBruger(Guid brugerId, string claim)
        {
            var bruger = await GetBruger(brugerId);
            await _userManager.RemoveClaimAsync(bruger, new Claim(claim, "Yes"));
        }
    }
}
