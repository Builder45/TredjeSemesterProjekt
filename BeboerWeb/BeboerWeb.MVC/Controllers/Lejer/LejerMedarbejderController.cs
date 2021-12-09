using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    [Authorize(Policy = "Lejer")]
    [Route("Dashboard/Lejer/Kontakter/{action}")]
    public class LejerMedarbejderController : Controller
    {
        private readonly ILejerService _lejerService;
        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string viewPath = "Views/Dashboard/Lejer/MedarbejderOplysninger";

        public LejerMedarbejderController(ILejerService lejerService, IPersonService personService,
            UserManager<IdentityUser> userManager, ApplicationDbContext userDb)
        {
            _lejerService = lejerService;
            _personService = personService;
            _userManager = userManager;
            _userDb = userDb;
        }

        public async Task<ActionResult> Index()
        {
            //var model = new List<MedarbejderViewModel>();
            //var personList = await _personService.GetPersonerAsync();
            //var brugerList = await _userDb.Users.ToListAsync();
            //foreach (var person in personList)
            //{
            //    var brugerModel = new MedarbejderViewModel();
            //    brugerModel.AddDataFromDTO(person);

            //    var bruger = brugerList.Find(bruger => bruger.Id == person.BrugerId.ToString());
            //    if (bruger != null)
            //    {
            //    }

            //    model.Add(brugerModel);
            //}
            return View($"{viewPath}/Index.cshtml"/*, model*/);
        }
    }
}
