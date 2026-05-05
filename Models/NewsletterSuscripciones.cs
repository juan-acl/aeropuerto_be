using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("NEWSLETTER_SUSCRIPCIONES")]
    public class NewsletterSuscripciones
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SUSCRIPCION_NEWSLETTER")]
        public int IdSuscripcionNewsletter { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal? IdPasajero { get; set; }
        
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        
        [Column("NOMBRE")]
        public string? Nombre { get; set; }
        
        [Column("FECHA_SUSCRIPCION")]
        public DateTime? FechaSuscripcion { get; set; }
        
        [Column("FECHA_BAJA")]
        public DateTime? FechaBaja { get; set; }
        
        [Column("FRECUENCIA")]
        public string? Frecuencia { get; set; }
        
        [Column("TEMAS_INTERES")]
        public string? TemasInteres { get; set; }
        
        [Column("CONFIRMADO")]
        public decimal? Confirmado { get; set; }
        
        [Column("TOKEN_CONFIRMACION")]
        public string? TokenConfirmacion { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}

