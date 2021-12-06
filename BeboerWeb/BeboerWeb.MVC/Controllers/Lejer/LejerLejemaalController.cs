using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace BeboerWeb.MVC.Controllers.Lejer
{
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

        //[Route("")]
        public async Task<ActionResult> IndexByLejer()
        {
            //var user = _userManager.GetUserIdAsync(HttpContext.User.);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dtos = await _lejemaalService.GetLejerLejemaal(Guid.Parse(userId));
            
            var model = new List<LejemaalViewModel>();
            foreach (var dto in dtos)
            {
                var lejemaal = new LejemaalViewModel();
                lejemaal.AddDataFromDto(dto);
                model.Add(lejemaal);
            }

            return View($"{viewPath}/Details.cshtml", model);
        }

        // GET: LejerLejemaalController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = new LejemaalViewModel();
            model.Id = id;
            return View($"{viewPath}/Index.cshtml", model);
        }

        // GET: LejerLejemaalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejerLejemaalController/Create
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

        // GET: LejerLejemaalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejerLejemaalController/Edit/5
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

        // GET: LejerLejemaalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejerLejemaalController/Delete/5
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
