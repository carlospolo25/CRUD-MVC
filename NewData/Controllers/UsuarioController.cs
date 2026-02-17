using Microsoft.AspNetCore.Mvc;
using NewData.Models;

namespace NewData.Controllers
{
    public class UsuarioController : Controller
    {
        private MiDbContext _context;

        public UsuarioController(MiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View("~/Views/Usuario/Registrar.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Usuario usuario)
        {
            usuario.RoLId = 2;
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                Console.WriteLine("Errores de validación: " + errors);
                return View("~/Views/Usuario/Registrar.cshtml");
            }

            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Ocuarrió un error al registrase" +  ex.Message);
                return View("~/Views/Usuario/Registrar.cshtml", usuario);
            }

            return RedirectToAction("Inicio");

        }

        [HttpGet]
        public IActionResult Inicio()
        {
            return View("~/Views/Usuario/Inicio.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Inicio (String Correo, String Contrasena)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(U => U.Correo == Correo && U.Contrasena == Contrasena);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return View("~/Views/Usuario/Inicio.cshtml");
            }

            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);  
            HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
            HttpContext.Session.SetInt32("RoLId", usuario.RoLId);

            if (usuario.RoLId == 1)
            {
                return RedirectToAction("Gestion", "Gestion");

            }
            else
            {

                return RedirectToAction("Producto", "Producto");
            }
        }


    }
}