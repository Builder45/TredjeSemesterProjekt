using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.BA
{
    public class BALejerController : Controller
    {
        private readonly ILejerService _lejerService;

        private readonly string viewPath = "Views/Dashboard/BA/Lejer";

        public BALejerController(ILejerService lejerService)
        {
            _lejerService = lejerService;
        }

        public async Task<ActionResult> IndexByLejemaal(Guid id)
        {
            var dtos = await _lejerService.GetLejereByLejemaalAsync(id);
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

        public ActionResult Create()
        {
            return View($"{viewPath}/Create.cshtml");
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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
