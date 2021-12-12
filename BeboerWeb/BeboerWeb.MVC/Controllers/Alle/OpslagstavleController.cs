using BeboerWeb.API.Contract;
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
        private readonly string viewPath = "Views/Dashboard/Alle/Opslagstavle";

        public OpslagstavleController(IOpslagService opslagService)
        {
            _opslagService = opslagService; 
        }

        public ActionResult Index()
        {
            return View($"{viewPath}/Index.cshtml");
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
