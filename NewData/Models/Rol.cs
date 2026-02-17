using NewData.Models;
namespace NewData.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string  Nombre { get; set; } 

        public ICollection<Usuario> Usuario { get; set; }
    }
}
