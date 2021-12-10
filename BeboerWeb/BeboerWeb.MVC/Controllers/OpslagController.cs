﻿using System.Security.Claims;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers
{
    public class OpslagController : Controller
    {
        private readonly IEjendomService _ejendomService;
        private readonly string viewPath = "Views/Dashboard/Opslag";

        public OpslagController(IEjendomService ejendomService)
        {
            _ejendomService = ejendomService;
        }

        public async Task<ActionResult> Index()
        {

            var dtos = await _ejendomService.GetEjendommeAsync();

            var model = new List<OpslagToEjendomViewModel>();
            foreach (var dto in dtos)
            {
                var opslag = new OpslagToEjendomViewModel();
                opslag.GetOpslagDTO(dto);
                model.Add(opslag);
            }

            return View($"{viewPath}/Index.cshtm");
        }

        // GET: OpslagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OpslagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpslagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OpslagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpslagController/Edit/5
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
