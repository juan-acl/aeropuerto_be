using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public string Genero { get; set; } = null!; // 'M', 'F', 'O'
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public string Departamento { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public decimal SalarioBase { get; set; }
        public string TipoContrato { get; set; } = null!;
        public int Activo { get; set; } = 1;
        public byte[]? FotoEmpleado { get; set; }
    }
}