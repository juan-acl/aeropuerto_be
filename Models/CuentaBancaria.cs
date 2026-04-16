using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class CuentaBancaria
    {
        [Key]
        public int IdCuentaBanco { get; set; }
        public string Banco { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal Saldo { get; set; }
        public string Moneda { get; set; } = "GTQ";
        public int Activo { get; set; } = 1;
    }
}