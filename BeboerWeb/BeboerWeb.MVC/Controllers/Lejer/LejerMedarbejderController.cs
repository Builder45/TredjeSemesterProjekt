using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    [Authorize(Policy = "Lejer")]
    [Route("Dashboard/Lejer/Kontakter/{action}")]
    public class LejerMedarbejderController : Controller
    {
        private readonly ILejerService _lejerService;
        private readonly IPersonService _personService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string viewPath = "Views/Dashboard/Lejer/MedarbejderOplysninger";

        public LejerMedarbejderController(ILejerService lejerService, IPersonService personService,
            UserManager<IdentityUser> userManager)
        {
            _lejerService = lejerService;
            _personService = personService;
            _userManager = userManager;
        }

        public async Task<ActionResult> IndexByLejer()
        {
            return View($"{viewPath}/Details.cshtml");
        }

        public ActionResult Index()
        {
            return View($"{viewPath}/Index.cshtml");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
