using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("NOTIFICACIONES_OACI")]
    public class NotificacionesOaci
    {
        
        [Key]
        [Column("ID_NOTIFICACION_OACI")]
        public int IdNotificacionOaci { get; set; }
        
        [Column("NUMERO_NOTIFICACION")]
        public string NumeroNotificacion { get; set; } = null!;
        
        [Column("FECHA_RECEPCION")]
        public DateTime? FechaRecepcion { get; set; }
        
        [Column("TIPO_NOTIFICACION")]
        public string? TipoNotificacion { get; set; }
        
        [Column("ASUNTO")]
        public string Asunto { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("FECHA_LIMITE_CUMPLIMIENTO")]
        public DateTime? FechaLimiteCumplimiento { get; set; }
        
        [Column("DOCUMENTO_NOTIFICACION")]
        public byte[]? DocumentoNotificacion { get; set; }
        
        [Column("AREA_RESPONSABLE")]
        public decimal? AreaResponsable { get; set; }
        
        [Column("ESTADO_CUMPLIMIENTO")]
        public string? EstadoCumplimiento { get; set; }
        
        [Column("FECHA_CUMPLIMIENTO")]
        public DateTime? FechaCumplimiento { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
