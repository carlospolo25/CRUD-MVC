using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewData.Models
{
    public class MiDbContextFactory : IDesignTimeDbContextFactory<MiDbContext>
    {
        public MiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MiDbContext>();

            // Aquí tu cadena de conexión directamente
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NewDataDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MiDbContext(optionsBuilder.Options);
        }
    }
}
