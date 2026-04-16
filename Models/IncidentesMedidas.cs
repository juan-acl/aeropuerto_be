using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES_MEDIDAS")]
    public class IncidentesMedidasModel
    {
        [Key]
        [Column("ID_MEDIDA")]
        public int IdMedida { get; set; }

        [Column("ID_INCIDENTE")]
        public int IdIncidente { get; set; }

        [Column("TIPO_MEDIDA")]
        public string TipoMedida { get; set; } = null!; // ADVERTENCIA, MULTA, etc.

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("FECHA_APLICACION")]
        public DateTime? FechaAplicacion { get; set; }

        [Column("APLICADO_POR")]
        public string? AplicadoPor { get; set; }

        [Column("VIGENCIA_DIAS")]
        public int? VigenciaDias { get; set; }

        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}