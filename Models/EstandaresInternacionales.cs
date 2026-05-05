using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ESTANDARES_INTERNACIONALES")]
    public class EstandaresInternacionales
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ESTANDAR")]
        public decimal IdEstandar { get; set; }
        
        [Column("CODIGO_ESTANDAR")]
        public string CodigoEstandar { get; set; } = null!;
        
        [Column("NOMBRE_ESTANDAR")]
        public string NombreEstandar { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("ORGANISMO_EMISOR")]
        public string? OrganismoEmisor { get; set; }
        
        [Column("FECHA_PUBLICACION")]
        public DateTime? FechaPublicacion { get; set; }
        
        [Column("VERSION")]
        public string? Version { get; set; }
        
        [Column("FECHA_VIGENCIA")]
        public DateTime? FechaVigencia { get; set; }
        
        [Column("OBLIGATORIO")]
        public decimal? Obligatorio { get; set; }
        
        [Column("DOCUMENTO_ESTANDAR")]
        public byte[]? DocumentoEstandar { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
