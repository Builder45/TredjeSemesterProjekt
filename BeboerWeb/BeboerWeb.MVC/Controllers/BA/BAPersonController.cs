﻿using BeboerWeb.API.Contract;
using Microsoft.AspNetCore.Http;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Mvc;
using BeboerWeb.MVC.Data;
using BeboerWeb.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Controllers.BA
{
    [Route("Dashboard/Admin/Brugere/[action]")]
    public class BAPersonController : Controller
    {

        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _userDb;

        public BAPersonController(IPersonService personService, ApplicationDbContext userDb)
        {
            _userDb = userDb;
            _personService = personService;
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<BrugerViewModel>();
            var personList = await _personService.GetPersonsAsync();
            var brugerList = await _userDb.Users.ToListAsync();
            foreach (var person in personList)
            {
                var brugerModel = new BrugerViewModel();
                brugerModel.AddDataFromDTO(person);

                var bruger = brugerList.Find(bruger => bruger.Id == person.BrugerId.ToString());
                if (bruger != null)
                {
                    brugerModel.Email = bruger.Email;
                }

                model.Add(brugerModel);
            }
            return View("Views/Dashboard/BA/Person/Index.cshtml", model);
        }

        // GET: BrugerController/Details/5
        public ActionResult Details(int id)
        {
            return View("Views/Dashboard/BA/Person/Details.cshtml");
        }

        // GET: BrugerController/Create
        public ActionResult Create()
        {
            //return View("Areas/Identity/Pages/Account/Register.cshtml");
            return Redirect("~/Identity/Account/Register");
        }

        // POST: BrugerController/Create
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

        // GET: BrugerController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var personModel = await _personService.GetPersonByPersonIdAsync(id);
            var model = new BrugerViewModel();
            model.AddDataFromDTO(personModel);

            var bruger = await _userDb.Users.FindAsync(model.BrugerId.ToString());
            if (bruger != null)
            {
                model.Email = bruger.Email;
            }

            return View("Views/Dashboard/BA/Person/Edit.cshtml", model);
        }

        // POST: BrugerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(Guid id, BrugerViewModel bruger)
        {
            if (id != bruger.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _personService.UpdatePersonAsync(new PersonDTO { BrugerId = bruger.BrugerId, Fornavn = bruger.Fornavn, Efternavn = bruger.Efternavn, Id = bruger.Id, Telefonnr = bruger.Telefonnr});
                return RedirectToAction(nameof(Index));
            }
            return View("Views/Dashboard/BA/Person/Edit.cshtml", bruger);
        }

        // GET: BrugerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrugerController/Delete/5
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
