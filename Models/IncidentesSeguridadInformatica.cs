using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES_SEGURIDAD_INFORMATICA")]
    public class IncidentesSeguridadInformatica
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_INCIDENTE_SEGURIDAD_INFO")]
        public int IdIncidenteSeguridadInfo { get; set; }
        
        [Column("FECHA_DETECCION")]
        public DateTime? FechaDeteccion { get; set; }
        
        [Column("TIPO_INCIDENTE")]
        public string? TipoIncidente { get; set; }
        
        [Column("NIVEL_GRAVEDAD")]
        public string? NivelGravedad { get; set; }
        
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        
        [Column("IP_ORIGEN")]
        public string? IpOrigen { get; set; }
        
        [Column("USUARIO_AFECTADO")]
        public decimal? UsuarioAfectado { get; set; }
        
        [Column("ACCIONES_TOMADAS")]
        public string? AccionesTomadas { get; set; }
        
        [Column("FECHA_RESOLUCION")]
        public DateTime? FechaResolucion { get; set; }
        
        [Column("RESPONSABLE_RESOLUCION")]
        public decimal? ResponsableResolucion { get; set; }
        
        [Column("REQUIERE_NOTIFICACION_LEGAL")]
        public decimal? RequiereNotificacionLegal { get; set; }
        
        [Column("NOTIFICADO_LEGAL")]
        public decimal? NotificadoLegal { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        

    }
}
