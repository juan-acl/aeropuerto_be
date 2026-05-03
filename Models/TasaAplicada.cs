using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TASAS_APLICADAS")]
    public class TasaAplicada
    {
        [Key]
        [Column("ID_APLICACION")]
        public int id_aplicacion { get; set; }

        [Column("ID_TASA")]
        public int? id_tasa { get; set; }

        [Column("ID_VUELO")]
        public int? id_vuelo { get; set; }

        [Column("ID_RESERVA")]
        public int? id_reserva { get; set; }

        [Column("FECHA_APLICACION")]
        public DateTime? fecha_aplicacion { get; set; }

        [Column("MONTO_APLICADO")]
        public decimal? monto_aplicado { get; set; }

        [Column("FACTURADO")]
        public int? facturado { get; set; }

        [Column("FECHA_FACTURA")]
        public DateTime? fecha_factura { get; set; }
    }
}