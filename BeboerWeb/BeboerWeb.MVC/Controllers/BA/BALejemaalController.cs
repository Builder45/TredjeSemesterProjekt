using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    [Route("dashboard/admin/lejemaal/")]
    public class BALejemaalController : Controller
    {
        private readonly ILejemaalService _lejemmalService;
        private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly string viewPath = "Views/Dashboard/BA/Lejemaal";

        public BALejemaalController(ILejemaalService lejemallService, ApplicationDbContext userDb, UserManager<IdentityUser> userManager)
        {
            _userDb = userDb;
            _lejemmalService = lejemallService;
            _userManager = userManager;
        }


        [Route("")]
        public async Task<ActionResult> Index()
        {
            var model = new List<BrugerViewModel>();
            var personList = await _lejemmalService.GetLejemaalAsync();
            var brugerList = await _userDb.Users.ToListAsync();
            foreach (var person in personList)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(lejemaal);

                var bruger = brugerList.Find(bruger => bruger.Id == person.BrugerId.ToString());
                if (bruger != null)
                {
                    brugerModel.Email = bruger.Email;
                }

                model.Add(brugerModel);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        // GET: LejemaalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LejemaalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejemaalController/Create
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

        // GET: LejemaalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejemaalController/Edit/5
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

        // GET: LejemaalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejemaalController/Delete/5
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
