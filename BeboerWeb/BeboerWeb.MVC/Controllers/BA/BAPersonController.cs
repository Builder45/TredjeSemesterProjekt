
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    //[Route("dashboard/admin/brugere/")]
    public class BAPersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IVicevaertService _vicevaertService;
        private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly string viewPath = "Views/Dashboard/BA/Person";

        public BAPersonController(IPersonService personService, ApplicationDbContext userDb, UserManager<IdentityUser> userManager, IVicevaertService vicevaertService)
        {
            _userDb = userDb;
            _personService = personService;
            _vicevaertService = vicevaertService;
            _userManager = userManager;
        }

        //[Route("")]
        public async Task<ActionResult> Index()
        {
            var model = new List<BrugerViewModel>();
            var personList = await _personService.GetPersonsAsync();
            var brugerList = await _userDb.Users.ToListAsync();
            foreach (var person in personList)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(person);

                var bruger = brugerList.Find(bruger => bruger.Id == person.BrugerId.ToString());
                if (bruger != null)
                {
                    brugerModel.Email = bruger.Email;
                }

                model.Add(brugerModel);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        //[Route("opret")]
        public ActionResult Create()
        {
            return Redirect("~/Identity/Account/Register");
        }

        //[Route("rediger")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var personModel = await _personService.GetPersonByPersonIdAsync(id);
            var model = new BrugerViewModel();
            model.AddDataFromDTO(personModel);

            var bruger = await _userDb.Users.FindAsync(model.BrugerId.ToString());
            if (bruger != null)
            {
                model.Email = bruger.Email;
            }

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

        //[Route("roller")]
        public async Task<ActionResult> EditPolicies(Guid id)
        {
            var model = new UserPolicyViewModel
            {
                BrugerId = id
            };

            var user = await _userDb.Users.FindAsync(id.ToString());
            if (user != null) model.Email = user.Email;

            var userIsVV = _userDb.UserClaims
                .Any(c => c.UserId == id.ToString() && c.ClaimType == "IsVV" && c.ClaimValue == "Yes");
            if (userIsVV)
            {
                model.WasVV = true;
                model.IsVV = true;
            }

            return View($"{viewPath}/EditPolicies.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPolicies(UserPolicyViewModel model)
        {
            if (model.IsVV != model.WasVV)
            {
                var bruger = await _userManager.FindByIdAsync(model.BrugerId.ToString());
                if (model.IsVV)
                {
                    await _userManager.AddClaimAsync(bruger, new Claim("IsVV", "Yes"));
                    await _vicevaertService.LinkVicevaertAsync(new VicevaertDTO {BrugerId = model.BrugerId});
                }
                else
                {
                    await _userManager.RemoveClaimAsync(bruger, new Claim("IsVV", "Yes"));
                    await _vicevaertService.UnlinkVicevaertAsync(new VicevaertDTO { BrugerId = model.BrugerId });
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
