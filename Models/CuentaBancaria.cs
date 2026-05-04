using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CUENTAS_BANCARIAS")]
    public class CuentaBancaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
