using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ADUANA_CARGA")]
    public class AduanaCarga
    {
        [Key]
        [Column("ID_REVISION")]
        public int IdRevision { get; set; }
        [Column("ID_ENVIO")]
        public int IdEnvio { get; set; }
        [Column("ID_INSPECTOR")]
        public int IdInspector { get; set; }
        [Column("FECHA_REVISION")]
        public DateTime FechaRevision { get; set; }
        [Column("ESTADO_ADUANERO")]
        public string EstadoAduanero { get; set; } = null!; // LIBERADO, RETENIDO, RECHAZADO
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        [Column("IMPUESTOS_PAGADOS")]
        public decimal ImpuestosPagados { get; set; }
    }
}