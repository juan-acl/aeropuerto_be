using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class ProveedorRepuesto
    {
        [Key]
        public int IdProveedorRep { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Especialidad { get; set; } = null!; // MOTORES, FUSELAJE, ELECTRÓNICA
    }
}