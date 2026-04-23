using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INGRESO")]
    public class Ingreso
    {
        [Key]
        [Column("ID_INGRESO")]
        public int IdIngreso { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("FUENTE")]
        public string Fuente { get; set; } = null!; // Ejemplo: Tasas, Alquileres, etc.
        [Column("ID_CUENTA_CONTABLE")]
        public int IdCuentaContable { get; set; }
        [Column("METODO_PAGO")]
        public string MetodoPago { get; set; } = null!;
    }
}