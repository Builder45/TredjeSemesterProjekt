using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services.PersonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class BALejerController : Controller
    {
        private readonly ILejerService _lejerService;
        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;

        private readonly string viewPath = "Views/Dashboard/BA/Lejer";

        public BALejerController(ILejerService lejerService, IPersonService personService, ApplicationDbContext userDb)
        {
            _lejerService = lejerService;
            _personService = personService;
            _userDb = userDb;
        }

        public async Task<ActionResult> IndexByLejemaal(Guid id)
        {
            var dtos = await _lejerService.GetLejereByLejemaalAsync(id);
            if (dtos.Count == 0)
            {
                return RedirectToAction("Index", "BALejemaal");
            }

            var dtosInOrder = dtos.OrderByDescending(l => l.LejeperiodeStart);
            var model = new List<LejerViewModel>();
            foreach (var dto in dtosInOrder)
            {
                var lejer = new LejerViewModel();
                lejer.AddDataFromDto(dto);
                model.Add(lejer);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        public async Task<ActionResult> Create(Guid id)
        {
            var model = new LejerBrugerViewModel();
            var dtos = await _personService.GetPersonsAsync();
            var brugerModels = new List<BrugerViewModel>();

            foreach (var dto in dtos)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(dto);
                brugerModels.Add(brugerModel);
            }

            model.Brugere = brugerModels;
            model.Lejer.LejemaalId = id;

            return View($"{viewPath}/Create.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LejerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejer = new LejerDTO()
                {
                    LejeperiodeStart = model.LejeperiodeStart, 
                    LejeperiodeSlut = model.LejeperiodeSlut,
                    LejemaalId = model.LejemaalId
                };
                await _lejerService.CreateLejer(lejer);

                //var indexModel = new List<LejerViewModel>();
                //indexModel.Add(model);
                //return View($"{viewPath}/Index.cshtml", indexModel);
                return RedirectToAction("IndexByLejemaal", new {id = model.LejemaalId});
            }

            return View($"{viewPath}/Create.cshtml");
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
    }
}
