using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Ingreso
    {
        [Key]
        public int IdIngreso { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Fuente { get; set; } = null!; // Ejemplo: Tasas, Alquileres, etc.
        public int IdCuentaContable { get; set; }
        public string MetodoPago { get; set; } = null!;
    }
}