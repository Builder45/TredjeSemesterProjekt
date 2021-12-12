using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    [Route("Dashboard/Admin/Lejere/{action}")]
    public class BALejerController : Controller
    {
        private readonly ILejerService _lejerService;
        private readonly ILejemaalService _lejemaalService;
        private readonly IPersonService _personService;
        private readonly IBrugerService _brugerService;
        private readonly string viewPath = "Views/Dashboard/BA/Lejer";

        public BALejerController(ILejerService lejerService, ILejemaalService lejemaalService, IPersonService personService, IBrugerService brugerService)
        {
            _lejerService = lejerService;
            _lejemaalService = lejemaalService;
            _personService = personService;
            _brugerService = brugerService;
        }

        public async Task<ActionResult> IndexByLejemaal(Guid id)
        {
            var model = new LejemaalLejerViewModel();
            var lejemaalDto = await _lejemaalService.GetLejemaalAsync(id);
            model.Lejemaal.AddDataFromDto(lejemaalDto);

            var dtos = await _lejerService.GetLejereByLejemaalAsync(id);
            var dtosInOrder = dtos.OrderByDescending(l => l.LejeperiodeStart);
            foreach (var dto in dtosInOrder)
            {
                var lejer = new LejerViewModel();
                lejer.AddDataFromDto(dto);
                model.Lejere.Add(lejer);
            }

            return View($"{viewPath}/Index.cshtml", model);
        }

        public async Task<ActionResult> Create(Guid id)
        {
            var model = new LejerBrugerViewModel();
            model.Lejer.LejemaalId = id;

            var personer = await _personService.GetPersonerAsync();
            var brugere = await _brugerService.GetBrugere();
            foreach (var person in personer)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(person);
                var bruger = brugere.Find(b => b.Id == person.BrugerId.ToString());
                if (bruger != null) brugerModel.Email = bruger.Email;
                model.Brugere.Add(brugerModel);
            }

            return View($"{viewPath}/Create.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LejerBrugerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejer = new LejerDTO()
                {
                    LejeperiodeStart = model.Lejer.LejeperiodeStart, 
                    LejeperiodeSlut = model.Lejer.LejeperiodeSlut,
                    LejemaalId = model.Lejer.LejemaalId,
                    PersonIds = model.Lejer.PersonIds
                };
                await _lejerService.CreateLejerAsync(lejer);
                return RedirectToAction("IndexByLejemaal", new {id = model.Lejer.LejemaalId });
            }

            return View($"{viewPath}/Create.cshtml");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = new LejerBrugerViewModel();
            var dto = await _lejerService.GetLejerAsync(id);
            model.Lejer.AddDataFromDto(dto);

            var personer = await _personService.GetPersonerAsync();
            var brugere = await _brugerService.GetBrugere();
            foreach (var person in personer)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(person);
                var bruger = brugere.Find(b => b.Id == person.BrugerId.ToString());
                if (bruger != null) brugerModel.Email = bruger.Email;
                model.Brugere.Add(brugerModel);
            }

            return View($"{viewPath}/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LejerBrugerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejer = model.GetLejerDTO();
                await _lejerService.UpdateLejerAsync(lejer);
                return RedirectToAction("IndexByLejemaal", new { id = model.Lejer.LejemaalId });
            }

            return View($"{viewPath}/Edit.cshtml");
        }
    }
}
