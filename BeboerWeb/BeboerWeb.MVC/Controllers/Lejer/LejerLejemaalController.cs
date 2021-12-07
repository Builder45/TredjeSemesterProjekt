using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    [Authorize(Policy = "Lejer")]
    [Route("Dashboard/Lejer/MineLejemaal/{action}")]
    public class LejerLejemaalController : Controller
    {
        private readonly ILejemaalService _lejemaalService;
        private readonly IEjendomService _ejendomService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string viewPath = "Views/Dashboard/Lejer/Lejemaal";

        public LejerLejemaalController(ILejemaalService lejemaalService, IEjendomService ejendomService, UserManager<IdentityUser> userManager)
        {
            _lejemaalService = lejemaalService;
            _ejendomService = ejendomService;
            _userManager = userManager;
        }

        public async Task<ActionResult> IndexByLejer()
        {
            //var user = _userManager.GetUserIdAsync(HttpContext.User.);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dtos = await _lejemaalService.GetLejemaalsByBrugerAsync(Guid.Parse(userId));
            
            var model = new List<LejemaalLejerViewModel>();
            foreach (var dto in dtos)
            {
                var lejemaal = new LejemaalLejerViewModel();
                lejemaal.AddDataFromDto(dto);
                model.Add(lejemaal);
            }



            return View($"{viewPath}/Details.cshtml", model);
        }

        public ActionResult Details(Guid id)
        {
            var model = new LejemaalViewModel();
            model.Id = id;
            return View($"{viewPath}/Index.cshtml", model);
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
