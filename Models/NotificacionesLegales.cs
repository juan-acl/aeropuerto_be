using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("NOTIFICACIONES_LEGALES")]
    public class NotificacionesLegales
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_NOTIFICACION_LEGAL")]
        public int IdNotificacionLegal { get; set; }
        
        [Column("NUMERO_NOTIFICACION")]
        public string NumeroNotificacion { get; set; } = null!;
        
        [Column("REMITENTE_NOMBRE")]
        public string RemitenteNombre { get; set; } = null!;
        
        [Column("REMITENTE_TIPO")]
        public string? RemitenteTipo { get; set; }
        
        [Column("DESTINATARIO_INTERNO")]
        public decimal? DestinatarioInterno { get; set; }
        
        [Column("ASUNTO")]
        public string Asunto { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("FECHA_RECEPCION")]
        public DateTime? FechaRecepcion { get; set; }
        
        [Column("FECHA_RESPUESTA_REQUERIDA")]
        public DateTime? FechaRespuestaRequerida { get; set; }
        
        [Column("PRIORIDAD")]
        public string? Prioridad { get; set; }
        
        [Column("DOCUMENTO_RECIBIDO")]
        public byte[]? DocumentoRecibido { get; set; }
        
        [Column("AREA_RESPONSABLE")]
        public decimal? AreaResponsable { get; set; }
        
        [Column("USUARIO_ASIGNADO")]
        public decimal? UsuarioAsignado { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("FECHA_RESPUESTA")]
        public DateTime? FechaRespuesta { get; set; }
        
        [Column("RESPUESTA")]
        public string? Respuesta { get; set; }
        
        [Column("DOCUMENTO_RESPUESTA")]
        public byte[]? DocumentoRespuesta { get; set; }
        

    }
}
