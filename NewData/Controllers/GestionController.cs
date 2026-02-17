using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewData.Models;

namespace NewData.Controllers
{
    public class GestionController : Controller
    {
        private MiDbContext _context;
        public GestionController(MiDbContext context)
        {
            _context = context;
        }
        public IActionResult Gestion()
        {
            var productos = _context.Productos.ToList();
            return View(productos);

        }

        public IActionResult CrearProducto()

        {
            return View("~/Views/Gestion/Crear.cshtml");
        }

        public IActionResult EditarProducto( int id)

        {
            var productos = _context.Productos.ToList();

            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View("~/Views/Gestion/Editar.cshtml", producto); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuevoProducto(Producto producto, IFormFile ImagenArchivo)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Gestion/Crear.cshtml");
            if (ImagenArchivo != null && ImagenArchivo.Length > 0)
            {
                var nombreArchiivo = Guid.NewGuid().ToString() +
                    Path.GetExtension(ImagenArchivo.FileName);

                var ruta = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/imagenes",
                    nombreArchiivo
                    );

                using (var stream  = new FileStream(ruta, FileMode.Create))
                {
                    ImagenArchivo.CopyTo(stream);

                }

                producto.Imagen = nombreArchiivo;


            };


                _context.Productos.Add(producto);
                _context.SaveChanges();

                return RedirectToAction("Gestion");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductoEditado(Producto ProductoEditado )
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Gestion/Editar.cshtml", ProductoEditado);
            }

            var producto = _context.Productos.Find(ProductoEditado.Id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Nombre = ProductoEditado.Nombre;
            producto.Precio = ProductoEditado.Precio;
            producto.Stock = ProductoEditado.Stock;

            _context.SaveChanges();

            return RedirectToAction("Gestion");
        }

        [HttpPost]
        public IActionResult EliminarProducto (int id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Gestion");
        }

        public IActionResult ProteccionGestion()
        {
            var rolId = HttpContext.Session.GetInt32("RoLId");

            if (rolId != 1)
                return RedirectToAction("Inicio", "Usuario");

            var productos = _context.Productos.ToList();
            return View(productos);
        }

        public IActionResult GestionBuscar (string buscar)
        {
            var productos = _context.Productos.AsQueryable();
            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.ToLower().Contains(buscar.ToLower()));
            }

            return View("Gestion", productos.ToList());
        }

    }
}
