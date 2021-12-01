﻿using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
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
        private readonly ApplicationDbContext _userDb;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly string viewPath = "Views/Dashboard/BA/Lejemaal";

        public BALejemaalController(ILejemaalService lejemaalService, ApplicationDbContext userDb, UserManager<IdentityUser> userManager)
        {
            _userDb = userDb;
            _lejemaalService = lejemaalService;
            _userManager = userManager;
        }

        //[Route("")]
        public async Task<ActionResult> Index()
        {
            var dtos = await _lejemaalService.GetLejemaalAsync();
            var model = new List<LejemaalViewModel>();
            foreach (var dto in dtos)
            {
               var lejemaal = new LejemaalViewModel();
               lejemaal.AddDataFromDto(dto);
               model.Add(lejemaal);
            }
            return View("Views/Dashboard/BA/Lejemaal/Index.cshtml", model);
        }

        //[Route("detaljer")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //[Route("opret")]
        public ActionResult Create()
        {
            return View("Views/Dashboard/BA/Lejemaal/Create.cshtml");
        }

        // POST: LejemaalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(LejemaalDTO lejemaal)
        {
            if (ModelState.IsValid)
            {
                await _lejemaalService.CreateLejemaal(lejemaal);
                return RedirectToAction(nameof(Index));
            }

            return View("Views/Dashboard/BA/Lejemaal/Create.cshtml");
        }
        
        [Route("rediger")]
        public ActionResult Edit(int id)
        {
            return View("Views/Dashboard/BA/Lejemaal/Edit.cshtml");
        }

        // POST: LejemaalController/Edit/5
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
                return View("Views/Dashboard/BA/Lejemaal/Edit.cshtml");
            }
        }

        //[Route("slet")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejemaalController/Delete/5
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
