using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewData.Models;

namespace NewData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MiDbContext _context;

        public HomeController(MiDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Productos = _context.Productos.ToList();
            return View(Productos);
        }

        public IActionResult InicioSesion ()
        {
            return View("~/Views/Usuario/Inicio.cshtml");
        }
        public IActionResult RegistrarUsuario()
        {
            return View("~/Views/Usuario/Registrar.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestDB([FromServices] MiDbContext db)
        {
            try
            {
                var test = db.Productos.FirstOrDefault();
                return Content("Conexión exitosa");
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

    }
}
