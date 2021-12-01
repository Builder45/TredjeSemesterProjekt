﻿using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services.EjendomService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Authorize(Policy = "BA")]
    //[Route("dashboard/admin/lejemaal/")]
    public class BALejemaalController : Controller
    {
        private readonly ILejemaalService _lejemaalService;
        private readonly IEjendomService _ejendomService;

        private readonly string viewPath = "Views/Dashboard/BA/Lejemaal";

        public BALejemaalController(ILejemaalService lejemaalService, IEjendomService ejendomService)
        {
            _lejemaalService = lejemaalService;
            _ejendomService = ejendomService;
        }

        //[Route("")]
        public async Task<ActionResult> Index()
        {
            var dtos = await _lejemaalService.GetLejemaalAsync();
            var dtosInOrder = dtos.OrderBy(l => l.EjendomId).ThenBy(l => l.Adresse);
            var model = new List<LejemaalViewModel>();
            foreach (var dto in dtosInOrder)
            {
               var lejemaal = new LejemaalViewModel();
               lejemaal.AddDataFromDto(dto);
               model.Add(lejemaal);
            }
            return View($"{viewPath}/Index.cshtml", model);
        }

        //[Route("detaljer")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //[Route("opret")]
        public async Task<ActionResult> Create()
        {
            var model = new ComboViewModel();
            model.Ejendomme = new List<EjendomViewModel>();

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
        public async Task<ActionResult> Create(ComboViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejemaal = model.GetLejemaalDTO();
                await _lejemaalService.CreateLejemaal(lejemaal);
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Create.cshtml");
        }

        //[Route("rediger")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = new ComboViewModel();
            var lejemaalDto = await _lejemaalService.GetLejemaalByLejemaalIdAsync(id);

            model.Lejemaal = new LejemaalViewModel();
            model.Lejemaal.AddDataFromDto(lejemaalDto);

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
        public async Task<ActionResult> Edit(ComboViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lejemaal = model.GetLejemaalDTO();
                await _lejemaalService.UpdateLejemaalAsync(lejemaal);
                return RedirectToAction(nameof(Index));
            }

            return View($"{viewPath}/Edit.cshtml");
        }

        //[Route("slet")]
        public ActionResult Delete(int id)
        {
            return View();
        }

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
