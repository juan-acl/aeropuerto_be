using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INGRESOS")]
    public class Ingreso
    {
        [Key]
        [Column("ID_INGRESO")]
        public int id_ingreso { get; set; }

        [Column("FECHA")]
        public DateTime? fecha { get; set; }

        [Column("CONCEPTO")]
        public string? concepto { get; set; }

        [Column("TIPO_INGRESO")]
        public string? tipo_ingreso { get; set; } // TASA_EMBARQUE, CONCESIONES, ESTACIONAMIENTO, PUBLICIDAD, OTROS

        [Column("ID_CONCESION")]
        public int? id_concesion { get; set; }

        [Column("ID_VUELO")]
        public int? id_vuelo { get; set; }

        [Column("MONTO")]
        public decimal? monto { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("METODO_PAGO")]
        public string? metodo_pago { get; set; }

        [Column("COMPROBANTE")]
        public string? comprobante { get; set; }

        [Column("REGISTRADO_POR")]
        public int? registrado_por { get; set; }
    }
}