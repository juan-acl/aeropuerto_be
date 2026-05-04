using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("INGRESOS")]
    public class Ingreso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_INGRESO")]
        public int IdIngreso { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("CONCEPTO")]
        public string Descripcion { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("TIPO_INGRESO")]
        public string? Fuente { get; set; }
        [Column("ID_CONCESION")]
        public int? IdConcesion { get; set; }
        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        [Column("METODO_PAGO")]
        public string? MetodoPago { get; set; }
        [Column("COMPROBANTE")]
        public string? Comprobante { get; set; }
        [Column("REGISTRADO_POR")]
        public int? RegistradoPor { get; set; }
    }
}
