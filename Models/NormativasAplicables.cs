using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("NORMATIVAS_APLICABLES")]
    public class NormativasAplicables
    {
        
        [Key]
        [Column("ID_NORMATIVA")]
        public int IdNormativa { get; set; }
        
        [Column("CODIGO_NORMATIVA")]
        public string CodigoNormativa { get; set; } = null!;
        
        [Column("TITULO_NORMATIVA")]
        public string TituloNormativa { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("ENTIDAD_EMISORA")]
        public string? EntidadEmisora { get; set; }
        
        [Column("PAIS_ORIGEN")]
        public string? PaisOrigen { get; set; }
        
        [Column("AMBITO_APLICACION")]
        public string? AmbitoAplicacion { get; set; }
        
        [Column("FECHA_PUBLICACION")]
        public DateTime? FechaPublicacion { get; set; }
        
        [Column("FECHA_VIGENCIA")]
        public DateTime? FechaVigencia { get; set; }
        
        [Column("FECHA_ULTIMA_ACTUALIZACION")]
        public DateTime? FechaUltimaActualizacion { get; set; }
        
        [Column("VERSION")]
        public string? Version { get; set; }
        
        [Column("DOCUMENTO_OFICIAL")]
        public byte[]? DocumentoOficial { get; set; }
        
        [Column("URL_REFERENCIA")]
        public string? UrlReferencia { get; set; }
        
        [Column("OBLIGATORIA")]
        public decimal? Obligatoria { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
    }
}
