using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("REVISIONES_DOCUMENTOS")]
    public class RevisionesDocumentos
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_REVISION_DOCUMENTO")]
        public decimal IdRevisionDocumento { get; set; }
        
        [Column("ID_DOCUMENTO_IMPORTANTE")]
        public decimal IdDocumentosImportantes { get; set; }
        
        [Column("NUMERO_REVISION")]
        public decimal NumeroRevision { get; set; }
        
        [Column("FECHA_REVISION")]
        public DateTime? FechaRevision { get; set; }
        
        [Column("REVISOR")]
        public decimal Revisor { get; set; }
        
        [Column("CAMBIOS_REALIZADOS")]
        public string? CambiosRealizados { get; set; }
        
        [Column("VERSION_RESULTANTE")]
        public string? VersionResultante { get; set; }
        
        [Column("APROBADO")]
        public decimal? Aprobado { get; set; }
        
        [Column("APROBADO_POR")]
        public decimal? AprobadoPor { get; set; }
        
        [Column("FECHA_APROBACION")]
        public DateTime? FechaAprobacion { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        

    }
}
