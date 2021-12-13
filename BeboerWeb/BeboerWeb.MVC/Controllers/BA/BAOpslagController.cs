using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    [Authorize(Policy = "BA")]
    [Route("Dashboard/Admin/Opslag/{action}")]
    public class BAOpslagController : Controller
    {
        private readonly IEjendomService _ejendomService;
        private readonly IOpslagService _opslagService;
        private readonly string viewPath = "Views/Dashboard/BA/Opslag";

        public BAOpslagController(IEjendomService ejendomService, IOpslagService opslagService)
        {
            _ejendomService = ejendomService;
            _opslagService = opslagService;
        }

        public async Task<ActionResult> Index()
        {

            var dtos = await _opslagService.GetOpslagAsync();
            var dtosInOrder = dtos.OrderByDescending(o => o.Dato); 
            var model = new List<OpslagViewModel>();
            foreach (var dto in dtosInOrder)
            {
                var opslag = new OpslagViewModel();
                opslag.AddDataFromDto(dto);
                model.Add(opslag);
            }

            return View($"{viewPath}/Index.cshtml", model);
        }
        
        public async Task<ActionResult> Create()
        {
            var model = new OpslagEjendommeViewModel();
            var dtos = await _ejendomService.GetEjendommeAsync();
            foreach (var dto in dtos)
            {
                var ejendommodel = new EjendomViewModel();
                ejendommodel.AddDataFromDto(dto);
                model.Ejendomme.Add(ejendommodel);
            }
            return View($"{viewPath}/Create.cshtml", model);
        }

        // POST: OpslagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OpslagEjendommeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.GetOpslagDTO();
                dto.Dato = DateTime.Now;
                await _opslagService.CreateOpslagAsync(dto);

                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Create.cshtml", model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = new OpslagEjendommeViewModel();
            var dtos = await _ejendomService.GetEjendommeAsync();
            foreach (var dto in dtos)
            {
                var ejendommodel = new EjendomViewModel();
                ejendommodel.AddDataFromDto(dto);
                model.Ejendomme.Add(ejendommodel);
            }

            var opslagDto = await _opslagService.GetOpslagAsync(id);
            model.Opslag.AddDataFromDto(opslagDto);

            return View($"{viewPath}/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OpslagEjendommeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.GetOpslagDTO();
                await _opslagService.UpdateOpslagAsync(dto);
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Edit.cshtml", model);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            await _opslagService.DeleteOpslagAsync(id);
            return RedirectToAction("Index");
        }
    }
}
