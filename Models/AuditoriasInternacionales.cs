using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("AUDITORIAS_INTERNACIONALES")]
    public class AuditoriasInternacionales
    {
        
        [Key]
        [Column("ID_AUDITORIA_INTERNACIONAL")]
        public int IdAuditoriaInternacional { get; set; }
        
        [Column("ENTIDAD_AUDITORA")]
        public string EntidadAuditora { get; set; } = null!;
        
        [Column("FECHA_AUDITORIA")]
        public DateTime FechaAuditoria { get; set; }
        
        [Column("TIPO_AUDITORIA")]
        public string? TipoAuditoria { get; set; }
        
        [Column("ALCANCE")]
        public string Alcance { get; set; } = null!;
        
        [Column("AUDITORES")]
        public string? Auditores { get; set; }
        
        [Column("AREAS_AUDITADAS")]
        public string? AreasAuditadas { get; set; }
        
        [Column("HALLAZGOS")]
        public string? Hallazgos { get; set; }
        
        [Column("NO_CONFORMIDADES")]
        public string? NoConformidades { get; set; }
        
        [Column("RECOMENDACIONES")]
        public string? Recomendaciones { get; set; }
        
        [Column("FECHA_INFORME")]
        public DateTime? FechaInforme { get; set; }
        
        [Column("INFORME_AUDITORIA")]
        public byte[]? InformeAuditoria { get; set; }
        
        [Column("PLAZO_CORRECCION_DIAS")]
        public decimal? PlazoCorreccionDias { get; set; }
        
        [Column("FECHA_CIERRE")]
        public DateTime? FechaCierre { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
