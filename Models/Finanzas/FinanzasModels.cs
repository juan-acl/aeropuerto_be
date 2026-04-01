using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models.Finanzas
{
    [Table("PROVEEDORES")]
    public class Proveedor
    {
        [Key]
        [Column("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }

        [Column("NOMBRE_PROVEEDOR")]
        public string NombreProveedor { get; set; } = string.Empty;

        [Column("RUC_NIT")]
        public string? RucNit { get; set; }

        [Column("TIPO_PROVEEDOR")]
        public string? TipoProveedor { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

        [Column("PAIS")]
        public string? Pais { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("TASAS_AEROPORTUARIAS")]
    public class TasaAeroportuaria
    {
        [Key]
        [Column("ID_TASA")]
        public int IdTasa { get; set; }

        [Column("NOMBRE_TASA")]
        public string NombreTasa { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("TIPO_TASA")]
        public string TipoTasa { get; set; } = string.Empty;

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("MONEDA")]
        public string Moneda { get; set; } = "GTQ";

        [Column("APLICA_A")]
        public string? AplicaA { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("CUENTAS_BANCARIAS")]
    public class CuentaBancaria
    {
        [Key]
        [Column("ID_CUENTA")]
        public int IdCuenta { get; set; }

        [Column("NOMBRE_BANCO")]
        public string NombreBanco { get; set; } = string.Empty;

        [Column("NUMERO_CUENTA")]
        public string NumeroCuenta { get; set; } = string.Empty;

        [Column("TIPO_CUENTA")]
        public string TipoCuenta { get; set; } = string.Empty;

        [Column("MONEDA")]
        public string Moneda { get; set; } = "GTQ";

        [Column("TITULAR")]
        public string? Titular { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
