using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CUENTA_BANCARIA")]
    public class CuentaBancaria
    {
        [Key]
        [Column("ID_CUENTA_BANCO")]
        public int IdCuentaBanco { get; set; }
        [Column("BANCO")]
        public string Banco { get; set; } = null!;
        [Column("NUMERO_CUENTA")]
        public string NumeroCuenta { get; set; } = null!;
        [Column("TIPO_CUENTA")]
        public string TipoCuenta { get; set; } = null!;
        [Column("SALDO")]
        public decimal Saldo { get; set; }
        [Column("MONEDA")]
        public string Moneda { get; set; } = "GTQ";
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}