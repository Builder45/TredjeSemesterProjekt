using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    [Route("Dashboard/Admin/Brugere/{action}")]
    public class BAPersonController : Controller
    {
        private readonly IBrugerService _brugerService;
        private readonly IPersonService _personService;
        private readonly IVicevaertService _vicevaertService;
        private readonly string viewPath = "Views/Dashboard/BA/Person";

        public BAPersonController(IBrugerService brugerService, IPersonService personService, IVicevaertService vicevaertService)
        {
            _brugerService = brugerService;
            _personService = personService;
            _vicevaertService = vicevaertService;
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<BrugerViewModel>();
            var personer = await _personService.GetPersonerAsync();
            var brugere = await _brugerService.GetBrugere();
            foreach (var person in personer)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(person);
                var bruger = brugere.Find(b => b.Id == person.BrugerId.ToString());
                if (bruger != null) brugerModel.Email = bruger.Email;

                model.Add(brugerModel);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        public ActionResult Create()
        {
            return Redirect("~/Identity/Account/Register");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var personModel = await _personService.GetPersonAsync(id);
            var model = new BrugerViewModel();
            model.AddDataFromDTO(personModel);

            var bruger = await _brugerService.GetBruger(model.BrugerId);
            model.Email = bruger.Email;

            return View($"{viewPath}/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(BrugerViewModel bruger)
        {
            if (ModelState.IsValid)
            {
                await _personService.UpdatePersonAsync(new PersonDTO { BrugerId = bruger.BrugerId, Fornavn = bruger.Fornavn, Efternavn = bruger.Efternavn, Id = bruger.Id, Telefonnr = bruger.Telefonnr});
                return RedirectToAction(nameof(Index));
            }
            return View($"{viewPath}/Edit.cshtml", bruger);
        }

        public async Task<ActionResult> EditClaims(Guid id)
        {
            var model = new UserPolicyViewModel
            {
                BrugerId = id
            };

            var bruger = await _brugerService.GetBruger(id); 
            model.Email = bruger.Email;
            model.IsVV = await _brugerService.BrugerHasClaim(id, "IsVV");
            model.IsBA = await _brugerService.BrugerHasClaim(id, "IsBA");

            return View($"{viewPath}/EditClaims.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditClaims(UserPolicyViewModel model)
        {
            if (model.IsVV)
            {
                await _brugerService.AddClaimToBruger(model.BrugerId, "IsVV");
                await _vicevaertService.LinkVicevaertAsync(new VicevaertDTO { BrugerId = model.BrugerId });
            }
            else
            {
                await _brugerService.RemoveClaimFromBruger(model.BrugerId, "IsVV");
                await _vicevaertService.UnlinkVicevaertAsync(model.BrugerId);
            }

            if (model.IsBA)
            {
                await _brugerService.AddClaimToBruger(model.BrugerId, "IsBA");
                //await _boligadminService....
            }
            else
            {
                await _brugerService.RemoveClaimFromBruger(model.BrugerId, "IsBA");
                //await _boligadminService....
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
