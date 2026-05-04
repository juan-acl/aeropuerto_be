using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("DOCUMENTOS_REQUERIDOS_OPERACION")]
    public class DocumentosRequeridosOperacion
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DOCUMENTO_REQUERIDO")]
        public int IdDocumentoRequerido { get; set; }
        
        [Column("TIPO_OPERACION")]
        public string? TipoOperacion { get; set; }
        
        [Column("NOMBRE_DOCUMENTO")]
        public string NombreDocumento { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("OBLIGATORIO")]
        public decimal? Obligatorio { get; set; }
        
        [Column("FORMATO_ACEPTADO")]
        public string? FormatoAceptado { get; set; }
        
        [Column("ENTIDAD_EMISORA_REQUERIDA")]
        public string? EntidadEmisoraRequerida { get; set; }
        
        [Column("PERIODO_VALIDEZ_DIAS")]
        public decimal? PeriodoValidezDias { get; set; }
        
        [Column("REQUIERE_ORIGINAL")]
        public decimal? RequiereOriginal { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
