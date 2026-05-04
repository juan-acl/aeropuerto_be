using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("AUDITORIAS_INTERNAS")]
    public class AuditoriasInternas
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_AUDITORIA_INTERNA")]
        public int IdAuditoriaInterna { get; set; }
        
        [Column("CODIGO_AUDITORIA")]
        public string CodigoAuditoria { get; set; } = null!;
        
        [Column("TITULO")]
        public string Titulo { get; set; } = null!;
        
        [Column("TIPO_AUDITORIA")]
        public string? TipoAuditoria { get; set; }
        
        [Column("ALCANCE")]
        public string Alcance { get; set; } = null!;
        
        [Column("FECHA_INICIO_PLANEACION")]
        public DateTime? FechaInicioPlaneacion { get; set; }
        
        [Column("FECHA_FIN_PLANEACION")]
        public DateTime? FechaFinPlaneacion { get; set; }
        
        [Column("FECHA_INICIO_EJECUCION")]
        public DateTime? FechaInicioEjecucion { get; set; }
        
        [Column("FECHA_FIN_EJECUCION")]
        public DateTime? FechaFinEjecucion { get; set; }
        
        [Column("FECHA_INFORME")]
        public DateTime? FechaInforme { get; set; }
        
        [Column("AUDITOR_LIDER")]
        public decimal? AuditorLider { get; set; }
        
        [Column("EQUIPO_AUDITOR")]
        public string? EquipoAuditor { get; set; }
        
        [Column("AREAS_AUDITADAS")]
        public string? AreasAuditadas { get; set; }
        
        [Column("HALLAZGOS")]
        public string? Hallazgos { get; set; }
        
        [Column("NO_CONFORMIDADES")]
        public string? NoConformidades { get; set; }
        
        [Column("OPORTUNIDADES_MEJORA")]
        public string? OportunidadesMejora { get; set; }
        
        [Column("CONCLUSIONES")]
        public string? Conclusiones { get; set; }
        
        [Column("INFORME_FINAL")]
        public byte[]? InformeFinal { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
    }
}

