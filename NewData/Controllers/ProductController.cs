using Microsoft.AspNetCore.Mvc;
using NewData.Models;

namespace NewData.Controllers
{
    public class ProductoController : Controller
    {
        private readonly MiDbContext _context;

        public ProductoController(MiDbContext context)
        {
            _context = context;

        }
        public IActionResult Producto()
        {
            var Productos = _context.Productos.ToList();
            return View(Productos);
        }

        public IActionResult ProductoBuscar(string buscar)
        {
            var productos = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(buscar));
            }

            return View("Producto", productos.ToList());
        }


    }
}
