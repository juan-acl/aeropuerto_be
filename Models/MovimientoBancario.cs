using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MOVIMIENTO_BANCARIO")]
    public class MovimientoBancario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
