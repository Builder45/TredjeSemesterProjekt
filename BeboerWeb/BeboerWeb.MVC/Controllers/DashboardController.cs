using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IBrugerService _brugerService;
        private readonly IOpslagService _opslagService;

        public DashboardController(IPersonService personService, IBrugerService brugerService, IOpslagService opslagService)
        {
            _personService = personService;
            _brugerService = brugerService;
            _opslagService = opslagService;
        }

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
            if (person.IsActiveLejer) return await LejerIndex();
            return View("Alle/Index");
        }

        public async Task<ActionResult> LejerIndex()
        {
            var bruger = await _brugerService.GetBrugerByBrugernavn(User.Identity.Name);
            var model = new List<OpslagViewModel>();
            var dtos = await _opslagService.GetOpslagByBrugerAsync(Guid.Parse(bruger.Id));
            var dtosInOrder = dtos.OrderByDescending(o => o.Dato);

            foreach (var dto in dtosInOrder)
            {
                var opslag = new OpslagViewModel();
                opslag.AddDataFromDto(dto);
                model.Add(opslag);
            }

            return View("Lejer/Index", model);
        }

        public ActionResult ChangeEmail()
        {
            return Redirect("~/Identity/Account/Manage/Email");
        }
        public ActionResult ChangePassword()
        {
            return Redirect("~/Identity/Account/Manage/ChangePassword");
        }
    }
}
