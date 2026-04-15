using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("COMUNICACIONES_EMERGENCIA")]
    public class ComunicacionesEmergencia
    {
        
        [Key]
        [Column("ID_COMUNICACION_EMERGENCIA")]
        public decimal IdComunicacionEmergencia { get; set; }
        
        [Column("ID_ACTIVACION")]
        public decimal? IdActivacion { get; set; }
        
        [Column("FECHA_HORA_ENVIO")]
        public DateTime? FechaHoraEnvio { get; set; }
        
        [Column("TIPO_MENSAJE")]
        public string? TipoMensaje { get; set; }
        
        [Column("MEDIO_ENVIO")]
        public string? MedioEnvio { get; set; }
        
        [Column("DESTINATARIOS")]
        public string? Destinatarios { get; set; }
        
        [Column("CONTENIDO")]
        public string Contenido { get; set; } = null!;
        
        [Column("EMISOR")]
        public string? Emisor { get; set; }
        
        [Column("CONFIRMACION_RECIBIDO")]
        public decimal? ConfirmacionRecibido { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
