using Microsoft.EntityFrameworkCore;
using NewData.Models;

namespace NewData.Models
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Rol {  get; set; }    
    }
}
