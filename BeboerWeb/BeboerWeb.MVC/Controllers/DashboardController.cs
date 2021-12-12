using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IBrugerService _brugerService;

        public DashboardController(IPersonService personService, IBrugerService brugerService)
        {
            _personService = personService;
            _brugerService = brugerService; 
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var bruger = await _brugerService.GetBrugerByBrugernavn(User.Identity.Name);
            var brugerId = Guid.Parse(bruger.Id);
            var person = await _personService.GetPersonByBrugerAsync(brugerId);

            if (person.IsActiveLejer)
            {
                if (await _brugerService.BrugerHasClaim(brugerId, "IsLejer") == false)
                {
                    await _brugerService.AddClaimToBruger(brugerId, "IsLejer");
                }
            }
            else
            {
                if (await _brugerService.BrugerHasClaim(brugerId, "IsLejer"))
                {
                    await _brugerService.RemoveClaimFromBruger(brugerId, "IsLejer");
                }
            }

            if (await _brugerService.BrugerHasClaim(brugerId, "IsBA")) return View("BA/Index");
            if (await _brugerService.BrugerHasClaim(brugerId, "IsVV")) return View("VV/Index");
            if (person.IsActiveLejer) return View("Lejer/Index");
            return View("Alle/Index");
        }
    }
}
