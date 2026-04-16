using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CONCESIONES_COMERCIALES")]
    public class ConcesionesComercialesModel
    {
        [Key]
        [Column("ID_CONCESION")]
        public int IdConcesion { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("NOMBRE_COMERCIAL")]
        public string? NombreComercial { get; set; }

        [Column("TIPO_NEGOCIO")]
        public string TipoNegocio { get; set; } = null!; // RESTAURANTE, TIENDA, DUTY_FREE, etc.

        [Column("EMPRESA")]
        public string? Empresa { get; set; }

        [Column("RUC")]
        public string? Ruc { get; set; }

        [Column("REPRESENTANTE")]
        public string? Representante { get; set; }

        [Column("TELEFONO_CONTACTO")]
        public string? TelefonoContacto { get; set; }

        [Column("EMAIL_CONTACTO")]
        public string? EmailContacto { get; set; }

        [Column("FECHA_INICIO_CONCESION")]
        public DateTime? FechaInicioConcesion { get; set; }

        [Column("FECHA_FIN_CONCESION")]
        public DateTime? FechaFinConcesion { get; set; }

        [Column("CANON_MENSUAL")]
        public decimal? CanonMensual { get; set; }

        [Column("UBICACION_TERMINAL")]
        public string? UbicacionTerminal { get; set; }

        [Column("LOCAL_NUMERO")]
        public string? LocalNumero { get; set; }

        [Column("AREA_M2")]
        public decimal? AreaM2 { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}