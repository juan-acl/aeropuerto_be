using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("AUDITORIAS_SEGURIDAD")]
    public class AuditoriasSeguridad
    {
        
        [Key]
        [Column("ID_AUDITORIA_SEGURIDAD")]
        public int IdAuditoriaSeguridad { get; set; }
        
        [Column("FECHA_AUDITORIA")]
        public DateTime? FechaAuditoria { get; set; }
        
        [Column("TIPO_AUDITORIA")]
        public string? TipoAuditoria { get; set; }
        
        [Column("ENTIDAD_AUDITORA")]
        public string? EntidadAuditora { get; set; }
        
        [Column("ALCANCE")]
        public string? Alcance { get; set; }
        
        [Column("HALLAZGOS")]
        public string? Hallazgos { get; set; }
        
        [Column("RECOMENDACIONES")]
        public string? Recomendaciones { get; set; }
        
        [Column("FECHA_CIERRE")]
        public DateTime? FechaCierre { get; set; }
        
        [Column("RESPONSABLE_CIERRE")]
        public decimal? ResponsableCierre { get; set; }
        
        [Column("DOCUMENTO_AUDITORIA")]
        public byte[]? DocumentoAuditoria { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
