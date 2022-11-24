using Microsoft.AspNetCore.Mvc;
using ProyectoWEBAdministracionHorarios.Models;
using System.Diagnostics;

namespace ProyectoWEBAdministracionHorarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistroEmpleado()
        {
            return View();
        }
        public IActionResult RegistroHorario()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}