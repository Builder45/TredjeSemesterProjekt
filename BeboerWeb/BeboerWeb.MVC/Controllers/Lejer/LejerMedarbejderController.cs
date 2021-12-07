using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
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

        //[Route("")]
        //public async Task<ActionResult> IndexByLejer()
        //{
        //    //var user = _userManager.GetUserIdAsync(HttpContext.User.);
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var dtos = await _lejerService.GetLejerAsync(Guid.Parse(userId));

        //    var model = new List<LejemaalLejerViewModel>();
        //    foreach (var dto in dtos)
        //    {
        //        var lejemaal = new LejemaalLejerViewModel();
        //        lejemaal.AddDataFromDto(dto);
        //        model.Add(lejemaal);
        //    }
        //    return View($"{viewPath}/Details.cshtml", model);
        //}

        // GET: LejerMedarbejderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LejerMedarbejderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LejerMedarbejderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejerMedarbejderController/Create
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

        // GET: LejerMedarbejderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejerMedarbejderController/Edit/5
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

        // GET: LejerMedarbejderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejerMedarbejderController/Delete/5
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
