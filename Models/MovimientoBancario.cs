using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class MovimientoBancario
    {
        [Key]
        public int IdMovimiento { get; set; }
        public int IdCuentaBanco { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}