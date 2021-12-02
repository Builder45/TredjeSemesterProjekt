using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class BALokaleController : Controller
    {
        private readonly ILokaleService _lokaleService;
        private readonly IEjendomService _ejendomService;

        private readonly string viewPath = "Views/Dashboard/BA/Lokale";

        public BALokaleController(ILokaleService lokaleService, IEjendomService ejendomService)
        {
            _lokaleService = lokaleService;
            _ejendomService = ejendomService;
        }

        public async Task<ActionResult> Index()
        {
            var dtos = await _lokaleService.GetLokalerAsync();
            var dtosInOrder = dtos.OrderBy(l => l.EjendomId).ThenBy(l => l.Adresse);
            var model = new List<LokaleViewModel>();
            foreach (var dto in dtosInOrder)
            {
                var lokale = new LokaleViewModel();
                lokale.AddDataFromDto(dto);
                model.Add(lokale);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        public async Task<ActionResult> Create()
        {
            var model = new LokaleEjendommeViewModel
            {
                Ejendomme = new List<EjendomViewModel>()
            };

            var dtos = await _ejendomService.GetEjendommeAsync();
            foreach (var dto in dtos)
            {
                var ejendom = new EjendomViewModel();
                ejendom.AddDataFromDto(dto);
                model.Ejendomme.Add(ejendom);
            }

            return View($"{viewPath}/Create.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LokaleEjendommeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejemaal = model.GetLokaleDTO();
                await _lokaleService.CreateLokaleAsync(lejemaal);
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Create.cshtml");
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = new LokaleEjendommeViewModel();
            var lokaleDto = await _lokaleService.GetLokaleAsync(id);

            model.Lokale = new LokaleViewModel();
            model.Lokale.AddDataFromDto(lokaleDto);

            model.Ejendomme = new List<EjendomViewModel>();
            var dtos = await _ejendomService.GetEjendommeAsync();
            foreach (var dto in dtos)
            {
                var ejendom = new EjendomViewModel();
                ejendom.AddDataFromDto(dto);
                model.Ejendomme.Add(ejendom);
            }

            return View($"{viewPath}/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LokaleEjendommeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejemaal = model.GetLokaleDTO();
                await _lokaleService.UpdateLokaleAsync(lejemaal);
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Edit.cshtml");
        }
    }
}
