using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CERTIFICACIONES_INTERNACIONALES")]
    public class CertificacionesInternacionales
    {
        
        [Key]
        [Column("ID_CERTIFICACION_INTERNACIONAL")]
        public int IdCertificacionInternacional { get; set; }
        
        [Column("ID_ESTANDAR")]
        public decimal? IdEstandar { get; set; }
        
        [Column("NOMBRE_CERTIFICACION")]
        public string NombreCertificacion { get; set; } = null!;
        
        [Column("ORGANISMO_CERTIFICADOR")]
        public string OrganismoCertificador { get; set; } = null!;
        
        [Column("FECHA_EMISION")]
        public DateTime FechaEmision { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("ALCANCE_CERTIFICACION")]
        public string? AlcanceCertificacion { get; set; }
        
        [Column("NUMERO_CERTIFICADO")]
        public string NumeroCertificado { get; set; } = null!;
        
        [Column("DOCUMENTO_CERTIFICADO")]
        public byte[]? DocumentoCertificado { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("RESPONSABLE_SEGUIMIENTO")]
        public decimal? ResponsableSeguimiento { get; set; }
        
  
    }
}
