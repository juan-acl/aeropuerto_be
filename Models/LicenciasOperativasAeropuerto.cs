using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("LICENCIAS_OPERATIVAS_AEROPUERTO")]
    public class LicenciasOperativasAeropuerto
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_LICENCIA_OPERATIVA")]
        public int IdLicenciaOperativa { get; set; }
        
        [Column("CODIGO_LICENCIA")]
        public string CodigoLicencia { get; set; } = null!;
        
        [Column("NOMBRE_LICENCIA")]
        public string NombreLicencia { get; set; } = null!;
        
        [Column("TIPO_LICENCIA")]
        public string? TipoLicencia { get; set; }
        
        [Column("ENTIDAD_OTORGANTE")]
        public string? EntidadOtorgante { get; set; }
        
        [Column("FECHA_EMISION")]
        public DateTime FechaEmision { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("FECHA_RENOVACION")]
        public DateTime? FechaRenovacion { get; set; }
        
        [Column("ALCANCE")]
        public string? Alcance { get; set; }
        
        [Column("RESTRICCIONES")]
        public string? Restricciones { get; set; }
        
        [Column("DOCUMENTO_LICENCIA")]
        public byte[]? DocumentoLicencia { get; set; }
        
        [Column("RESPONSABLE_SEGUIMIENTO")]
        public decimal? ResponsableSeguimiento { get; set; }
        
        [Column("RENOVACION_AUTOMATICA")]
        public decimal? RenovacionAutomatica { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }

    }
}
