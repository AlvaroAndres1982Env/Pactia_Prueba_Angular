using System.ComponentModel.DataAnnotations;

namespace FBUsuarios.Modelo
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
    }
}
