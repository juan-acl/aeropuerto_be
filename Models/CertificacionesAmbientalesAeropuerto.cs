using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CERTIFICACIONES_AMBIENTALES_AEROPUERTO")]
    public class CertificacionesAmbientalesAeropuerto
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CERTIFICACION_AMBIENTAL")]
        public int IdCertificacionAmbiental { get; set; }
        
        [Column("CODIGO_CERTIFICACION")]
        public string? CodigoCertificacion { get; set; }
        
        [Column("NOMBRE_CERTIFICACION")]
        public string NombreCertificacion { get; set; } = null!;
        
        [Column("ENTIDAD_CERTIFICADORA")]
        public string? EntidadCertificadora { get; set; }
        
        [Column("FECHA_OBTENCION")]
        public DateTime FechaObtencion { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("NIVEL_CERTIFICACION")]
        public string? NivelCertificacion { get; set; }
        
        [Column("ALCANCE")]
        public string? Alcance { get; set; }
        
        [Column("DOCUMENTO_CERTIFICADO")]
        public byte[]? DocumentoCertificado { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("RESPONSABLE_SEGUIMIENTO")]
        public decimal? ResponsableSeguimiento { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
