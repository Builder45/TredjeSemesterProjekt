﻿using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class EjendomController : Controller
    {
        
        private readonly IEjendomService _ejendomService;

        public EjendomController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

         // GET: EjendomController
        public async Task<ActionResult> Index()
        {
            var model = await _ejendomService.GetEjendommeAsync();
            return View("Views/Dashboard/BA/Ejendom/Index.cshtml", model);
        }

        // GET: EjendomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EjendomController/Create
        public ActionResult Create()
        {
            return View("Views/Dashboard/BA/Ejendom/Create.cshtml");
        }

        // POST: EjendomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EjendomDTO ejendom)
        {
            if (ModelState.IsValid)
            {
                await _ejendomService.CreateEjendomAsync(ejendom);
                return RedirectToAction(nameof(Index));
            }

            return View("Views/Dashboard/BA/Ejendom/Create.cshtml", ejendom);
        }

        // GET: EjendomController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _ejendomService.GetEjendomByIdAsync(id);

            return View("Views/Dashboard/BA/Ejendom/Edit.cshtml", model);
        }

        // POST: EjendomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(Guid id, EjendomDTO ejendom)
        {
            if (ModelState.IsValid)
            {
                await _ejendomService.UpdateEjendomAsync(ejendom);
                return RedirectToAction(nameof(Index));
            }
            return View("Views/Dashboard/BA/Ejendom/Create.cshtml",ejendom);


        }

        // GET: EjendomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EjendomController/Delete/5
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