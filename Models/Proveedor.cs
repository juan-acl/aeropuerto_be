using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactoNombre { get; set; } = null!;
        public int Activo { get; set; } = 1;
    }
}