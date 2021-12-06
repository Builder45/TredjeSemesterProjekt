﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Lejer
{
    public class LejerMedarbejderController : Controller
    {
        // GET: LejerMedarbejderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LejerMedarbejderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LejerMedarbejderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LejerMedarbejderController/Create
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

        // GET: LejerMedarbejderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LejerMedarbejderController/Edit/5
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

        // GET: LejerMedarbejderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LejerMedarbejderController/Delete/5
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