using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MOVIMIENTOS_BANCARIOS")]
    public class MovimientoBancario
    {
        [Key]
        [Column("ID_MOVIMIENTO")]
        public int id_movimiento { get; set; }

        [Column("ID_CUENTA")]
        public int? id_cuenta { get; set; }

        [Column("FECHA")]
        public DateTime? fecha { get; set; }

        [Column("TIPO_MOVIMIENTO")]
        public string? tipo_movimiento { get; set; } // DEPOSITO, RETIRO, TRANSFERENCIA, PAGO, COBRO

        [Column("CONCEPTO")]
        public string? concepto { get; set; }

        [Column("MONTO")]
        public decimal? monto { get; set; }

        [Column("SALDO_RESULTANTE")]
        public decimal? saldo_resultante { get; set; }

        [Column("REFERENCIA")]
        public string? referencia { get; set; }

        [Column("CONCILIADO")]
        public int? conciliado { get; set; }
    }
}