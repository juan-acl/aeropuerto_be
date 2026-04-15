using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("DOCUMENTOS_IMPORTANTES")]
    public class DocumentosImportantes
    {
        
        [Key]
        [Column("ID_DOCUMENTO_IMPORTANTE")]
        public int IdDocumentoImportante { get; set; }
        
        [Column("CODIGO_DOCUMENTO")]
        public string CodigoDocumento { get; set; } = null!;
        
        [Column("TITULO")]
        public string Titulo { get; set; } = null!;
        
        [Column("TIPO_DOCUMENTO")]
        public string? TipoDocumento { get; set; }
        
        [Column("FECHA_CREACION")]
        public DateTime? FechaCreacion { get; set; }
        
        [Column("FECHA_REVISION")]
        public DateTime? FechaRevision { get; set; }
        
        [Column("VERSION")]
        public string? Version { get; set; }
        
        [Column("AUTOR")]
        public string? Autor { get; set; }
        
        [Column("AREA_RESPONSABLE")]
        public decimal? AreaResponsable { get; set; }
        
        [Column("PALABRAS_CLAVE")]
        public string? PalabrasClave { get; set; }
        
        [Column("RESUMEN")]
        public string? Resumen { get; set; }
        
        [Column("ARCHIVO_DIGITAL")]
        public byte[]? ArchivoDigital { get; set; }
        
        [Column("UBICACION_FISICA")]
        public string? UbicacionFisica { get; set; }
        
        [Column("CONFIDENCIAL")]
        public decimal? Confidencial { get; set; }
        
        [Column("NIVELES_ACCESO")]
        public string? NivelesAcceso { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
