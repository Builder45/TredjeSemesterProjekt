using System.Collections;
using System.Linq;
using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeboerWeb.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;
        public DashboardController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPersonService personService, ApplicationDbContext userDb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _personService = personService;
            _userDb = userDb;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var roleRelevantView = CheckRole();
            return await roleRelevantView;
        }

        // GET: BrugerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrugerController/Create
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrugerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

            var person = await _personService.GetPersonByUserIdAsync(Guid.Parse(userId));
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
