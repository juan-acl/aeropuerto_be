using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("NEWSLETTER_ENVIOS")]
    public class NewsletterEnvios
    {
        
        [Key]
        [Column("ID_ENVIO_NEWSLETTER")]
        public decimal IdEnvioNewsletter { get; set; }
        
        [Column("ID_SUSCRIPCION_NEWSLETTER")]
        public decimal IdSuscripcionNewsletter { get; set; }
        
        [Column("ID_CAMPANA_MARKETING")]
        public decimal? IdCampanaMarketing { get; set; }
        
        [Column("FECHA_ENVIO")]
        public DateTime? FechaEnvio { get; set; }
        
        [Column("ASUNTO")]
        public string? Asunto { get; set; }
        
        [Column("CONTENIDO")]
        public string? Contenido { get; set; }
        
        [Column("FORMATO")]
        public string? Formato { get; set; }
        
        [Column("ABIERTO")]
        public decimal? Abierto { get; set; }
        
        [Column("FECHA_APERTURA")]
        public DateTime? FechaApertura { get; set; }
        
        [Column("CLICKS")]
        public decimal? Clicks { get; set; }
        
        [Column("CONVERTIDO")]
        public decimal? Convertido { get; set; }
        

    }
}
