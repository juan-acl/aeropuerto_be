using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PLANES_EMERGENCIA")]
    public class PlanesEmergencia
    {
        
        [Key]
        [Column("ID_PLAN_EMERGENCIA")]
        public int IdPlanEmergencia { get; set; }
        
        [Column("CODIGO_PLAN")]
        public string CodigoPlan { get; set; } = null!;
        
        [Column("NOMBRE_PLAN")]
        public string NombrePlan { get; set; } = null!;
        
        [Column("TIPO_EMERGENCIA")]
        public string? TipoEmergencia { get; set; }
        
        [Column("NIVEL_ACTIVACION")]
        public string? NivelActivacion { get; set; }
        
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        
        [Column("PROCEDIMIENTO")]
        public string Procedimiento { get; set; } = null!;
        
        [Column("RESPONSABLE_ACTIVACION")]
        public string? ResponsableActivacion { get; set; }
        
        [Column("TIEMPO_RESPUESTA_ESTIMADO_MINUTOS")]
        public decimal? TiempoRespuestaEstimadoMinutos { get; set; }
        
        [Column("RECURSOS_REQUERIDOS")]
        public string? RecursosRequeridos { get; set; }
        
        [Column("VERSION")]
        public string? Version { get; set; }
        
        [Column("FECHA_CREACION")]
        public DateTime? FechaCreacion { get; set; }
        
        [Column("FECHA_ULTIMA_REVISION")]
        public DateTime? FechaUltimaRevision { get; set; }
        
        [Column("FECHA_PROXIMA_REVISION")]
        public DateTime? FechaProximaRevision { get; set; }
        
        [Column("DOCUMENTO_PLAN")]
        public byte[]? DocumentoPlan { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
