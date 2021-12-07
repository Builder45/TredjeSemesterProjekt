using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string viewPath = "Views/Dashboard/BA/Lejer";

        public BALejerController(ILejerService lejerService, IPersonService personService, UserManager<IdentityUser> userManager, ILejemaalService lejemaalService)
        {
            _lejerService = lejerService;
            _lejemaalService = lejemaalService;
            _personService = personService;
            _userManager = userManager;
        }

        public async Task<ActionResult> IndexByLejemaal(Guid id)
        {
            var lejemaal = await _lejemaalService.GetLejemaalAsync(id);
            ViewBag.LejemaalInfo = $"{lejemaal.Adresse} ({lejemaal.Etage})";

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
            var dtos = await _personService.GetPersonerAsync();
            var brugerModels = new List<BrugerViewModel>();
            

            foreach (var dto in dtos)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(dto);
                
                var tempIdentity = await _userManager.FindByIdAsync(dto.BrugerId.ToString());
                brugerModel.Email = await _userManager.GetEmailAsync(tempIdentity);
                brugerModels.Add(brugerModel);
            }

            model.Brugere = brugerModels;
            model.Lejer.LejemaalId = id;

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

                //var indexModel = new List<LejerViewModel>();
                //indexModel.Add(model);
                //return View($"{viewPath}/Index.cshtml", indexModel);
                return RedirectToAction("IndexByLejemaal", new {id = model.Lejer.LejemaalId });
            }

            return View($"{viewPath}/Create.cshtml");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = new LejerBrugerViewModel();
            var lejerDTO = await _lejerService.GetLejerAsync(id);

            model.Lejer = new LejerViewModel();
            model.Lejer.AddDataFromDto(lejerDTO);

            var dtos = await _personService.GetPersonerAsync();
            var brugerModels = new List<BrugerViewModel>();

            foreach (var dto in dtos)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(dto);

                var tempIdentity = await _userManager.FindByIdAsync(dto.BrugerId.ToString());
                brugerModel.Email = await _userManager.GetEmailAsync(tempIdentity);
                brugerModels.Add(brugerModel);
            }

            model.Brugere = brugerModels;

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
