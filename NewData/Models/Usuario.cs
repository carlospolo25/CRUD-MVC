namespace NewData.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public int RoLId { get; set; }  
        public Rol? Rol { get; set; }
    }
}
