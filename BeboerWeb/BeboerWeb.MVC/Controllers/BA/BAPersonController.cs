using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Http;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Route("Dashboard/Admin/Brugere/[action]")]
    public class BAPersonController : Controller
    {

        private readonly IPersonService _personService;
        public BAPersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _personService.GetPersonAsync();
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
            var model = await _personService.GetPersonByIdAsync(id);
            return View("Views/Dashboard/BA/Person/Edit.cshtml", model);
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
