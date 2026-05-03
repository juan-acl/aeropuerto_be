using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CUENTAS_BANCARIAS")]
    public class CuentaBancaria
    {
        [Key]
        [Column("ID_CUENTA")]
        public int id_cuenta { get; set; }

        [Column("BANCO")]
        public string? banco { get; set; }

        [Column("TIPO_CUENTA")]
        public string? tipo_cuenta { get; set; } // MONETARIA, AHORRO, INVERSION

        [Column("NUMERO_CUENTA")]
        public string? numero_cuenta { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("SALDO_ACTUAL")]
        public decimal? saldo_actual { get; set; }

        [Column("FECHA_APERTURA")]
        public DateTime? fecha_apertura { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; }

        [Column("RESPONSABLE")]
        public string? responsable { get; set; }
    }
}