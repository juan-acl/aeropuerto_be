using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDENES_MANTENIMIENTO_PREDICTIVO")]
    public class OrdenMantenimientoPredictivo
    {
        [Key]
        [Column("ID_ORDEN_MP")]
        public int id_orden_mp { get; set; }

        [Column("ID_ALERTA_TECNICA")]
        public int? id_alerta_tecnica { get; set; }

        [Column("ID_PIEZA")]
        public int? id_pieza { get; set; }

        [Column("ID_AVION_MATRICULA")]
        public string? id_avion_matricula { get; set; }

        [Column("FECHA_CREACION")]
        public DateTime? fecha_creacion { get; set; }

        [Column("PRIORIDAD")]
        public string? prioridad { get; set; } // BAJA, MEDIA, ALTA, URGENTE

        [Column("DESCRIPCION_TRABAJO")]
        public string? descripcion_trabajo { get; set; }

        [Column("TECNICO_ASIGNADO")]
        public int? tecnico_asignado { get; set; }

        [Column("FECHA_INICIO_ESTIMADA")]
        public DateTime? fecha_inicio_estimada { get; set; }

        [Column("FECHA_FIN_ESTIMADA")]
        public DateTime? fecha_fin_estimada { get; set; }

        [Column("FECHA_INICIO_REAL")]
        public DateTime? fecha_inicio_real { get; set; }

        [Column("FECHA_FIN_REAL")]
        public DateTime? fecha_fin_real { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; } // PENDIENTE, ASIGNADO, EN_PROCESO, COMPLETADO, CANCELADO

        [Column("HORAS_TRABAJADAS")]
        public decimal? horas_trabajadas { get; set; }

        [Column("COSTO_ESTIMADO")]
        public decimal? costo_estimado { get; set; }

        [Column("COSTO_REAL")]
        public decimal? costo_real { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}