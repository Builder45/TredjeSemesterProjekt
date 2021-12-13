using System.Runtime.InteropServices;
using BeboerWeb.API.Contract;
using BeboerWeb.MVC.Models;
using BeboerWeb.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeboerWeb.MVC.Controllers.Alle
{
    [Authorize]
    [Route("Opslagstavle/{action}")]
    public class OpslagstavleController : Controller
    {
        private readonly IOpslagService _opslagService;
        private readonly IBrugerService _brugerService;
        private readonly string viewPath = "Views/Dashboard/Alle/Opslagstavle";

        public OpslagstavleController(IOpslagService opslagService, IBrugerService brugerService)
        {
            _opslagService = opslagService;
            _brugerService = brugerService; 
        }

        public async Task<ActionResult> Index()
        {
            var bruger = await _brugerService.GetBrugerByBrugernavn(User.Identity.Name);
            var model = new List<OpslagViewModel>();
            var dtos = await _opslagService.GetOpslagByBrugerAsync(Guid.Parse(bruger.Id));
            var dtosInOrder = dtos.OrderByDescending(o => o.Dato);

            foreach (var dto in dtosInOrder)
            {
                
            }

            return View($"{viewPath}/Index.cshtml", model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
