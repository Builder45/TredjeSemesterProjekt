using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;

        public DashboardController(UserManager<IdentityUser> userManager, IPersonService personService, ApplicationDbContext userDb)
        {
            _userManager = userManager;
            _personService = personService;
            _userDb = userDb;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var roleRelevantView = CheckRole();
            return await roleRelevantView;
        }
        private async Task<ActionResult> CheckRole()
        {
            if (User.HasClaim("IsBA", "Yes"))
            {
                return View("BA/Index");
            }

            var userId = _userManager.GetUserId(User);
            var user = await _userDb.Users.FindAsync(userId);

            var userIsLejerClaim = _userDb.UserClaims
                .Any(c => c.UserId == userId.ToString() && c.ClaimType == "IsLejer" && c.ClaimValue == "Yes");

            var person = await _personService.GetPersonByBrugerAsync(Guid.Parse(userId));
            ViewBag.BrugerNavn = person.Fornavn +" "+ person.Efternavn;
            if (person.IsActiveLejer == true)
            {
                if (userIsLejerClaim)
                {
                    return View("Lejer/Index");
                }
                else
                {
                    var claim = new Claim("IsLejer", "Yes");
                    await _userManager.AddClaimAsync(user, claim);
                    return View("Lejer/Index");
                }
            }
            if (person.IsActiveLejer == false)
            {
                if (userIsLejerClaim)
                {
                    var claim = new Claim("IsLejer", "Yes");
                    await _userManager.RemoveClaimAsync(user, claim);
                }
            }

            return View("Bruger/Index");
        }
    }
}
