using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    public class BrugerController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public BrugerController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: BrugerController
        [Authorize]
        public ActionResult Index()
        {
            if (User.HasClaim("IsAdmin", "Yes"))
            {
                return View("BAIndex");
            }

            return View("AlmIndex");
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
    }
}
