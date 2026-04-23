using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MOVIMIENTO_BANCARIO")]
    public class MovimientoBancario
    {
        [Key]
        [Column("ID_MOVIMIENTO")]
        public int IdMovimiento { get; set; }
        [Column("ID_CUENTA_BANCO")]
        public int IdCuentaBanco { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("TIPO_MOVIMIENTO")]
        public string TipoMovimiento { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
    }
}