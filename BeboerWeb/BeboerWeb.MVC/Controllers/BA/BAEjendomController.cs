using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    [Route("Dashboard/Admin/Ejendomme/{action}")]
    public class BAEjendomController : Controller
    {
        private readonly IEjendomService _ejendomService;
        private readonly string viewPath = "Views/Dashboard/BA/Ejendom";

        public BAEjendomController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

        public async Task<ActionResult> Index()
        {
            var models = new List<EjendomViewModel>();
            var dtos = await _ejendomService.GetEjendommeAsync();
            foreach (var dto in dtos)
            {
                var model = new EjendomViewModel();
                model.AddDataFromDto(dto);
                models.Add(model);
            }
            return View($"{viewPath}/Index.cshtml", models);
        }

        public ActionResult Create()
        {
            return View($"{viewPath}/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EjendomViewModel ejendom)
        {
            if (ModelState.IsValid)
            {
                await _ejendomService.CreateEjendomAsync(new EjendomDTO 
                    {Adresse = ejendom.Adresse, By = ejendom.By, Postnr = ejendom.Postnr});
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Create.cshtml", ejendom);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var dto = await _ejendomService.GetEjendomAsync(id);
            var model = new EjendomViewModel();
            model.AddDataFromDto(dto);
            return View($"{viewPath}/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(EjendomViewModel ejendom)
        {
            if (ModelState.IsValid)
            {
                await _ejendomService.UpdateEjendomAsync(new EjendomDTO
                    { Id = ejendom.Id, Adresse = ejendom.Adresse, By = ejendom.By, Postnr = ejendom.Postnr });
                return RedirectToAction(nameof(Index));
            }
            return View($"{viewPath}/Create.cshtml", ejendom);
        }
    }
}
