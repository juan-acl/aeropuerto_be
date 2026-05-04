using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDEN_MANTENIMIENTO_PREDICTIVO")]
    public class OrdenMantenimientoPredictivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ORDEN_MANT")]
        public int IdOrdenMant { get; set; }
        [Column("ID_AERONAVE")]
        public int IdAeronave { get; set; }
        [Column("FECHA_PROGRAMADA")]
        public DateTime FechaProgramada { get; set; }
        [Column("TIPO_MANTENIMIENTO")]
        public string TipoMantenimiento { get; set; } = null!; // PREDICTIVO, PREVENTIVO
        [Column("ESTADO")]
        public string Estado { get; set; } = "PROGRAMADA";
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
