using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Http;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Route("Dashboard/Admin/Brugere/[action]")]
    public class BAPersonController : Controller
    {

        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;

        public BAPersonController(IPersonService personService, ApplicationDbContext userDb, UserManager<IdentityUser> userManager)
        {
            _userDb = userDb;
            _personService = personService;
            _userManager = userManager;
        }

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
            return View("Views/Dashboard/BA/Person/Index.cshtml", model);
        }

        // GET: BrugerController/Details/5
        public ActionResult Details(int id)
        {
            return View("Views/Dashboard/BA/Person/Details.cshtml");
        }

        // GET: BrugerController/Create
        public ActionResult Create()
        {
            //return View("Areas/Identity/Pages/Account/Register.cshtml");
            return Redirect("~/Identity/Account/Register");
        }

        // POST: BrugerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrugerController/Edit/5
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

            return View("Views/Dashboard/BA/Person/Edit.cshtml", model);
        }

        // POST: BrugerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(BrugerViewModel bruger)
        {
            if (ModelState.IsValid)
            {
                await _personService.UpdatePersonAsync(new PersonDTO { BrugerId = bruger.BrugerId, Fornavn = bruger.Fornavn, Efternavn = bruger.Efternavn, Id = bruger.Id, Telefonnr = bruger.Telefonnr});
                return RedirectToAction(nameof(Index));
            }
            return View("Views/Dashboard/BA/Person/Edit.cshtml", bruger);
        }

        public async Task<ActionResult> EditPolicies(Guid id)
        {
            var model = new UserPolicyViewModel();
            model.BrugerId = id;

            var user = await _userDb.Users.FindAsync(id.ToString());
            model.Email = user.Email;

            bool userIsVV = _userDb.UserClaims
                .Any(c => c.UserId == id.ToString() && c.ClaimType == "IsVV" && c.ClaimValue == "Yes");
            if (userIsVV)
            {
                model.WasVV = true;
                model.IsVV = true;
            }

            return View("Views/Dashboard/BA/Person/EditPolicies.cshtml", model);
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
                }
                else
                {
                    await _userManager.RemoveClaimAsync(bruger, new Claim("IsVV", "Yes"));
                }
            }

            return View();
        }

        // GET: BrugerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrugerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
