using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("LOGS_ACCESO_SISTEMA")]
    public class LogsAccesoSistema
    {
        
        [Key]
        [Column("ID_LOG_ACCESO")]
        public decimal IdLogAcceso { get; set; }
        
        [Column("ID_USUARIO_SISTEMA")]
        public decimal? IdUsuarioSistema { get; set; }
        
        [Column("TIMESTAMP_ACCESO")]
        public DateTime? TimestampAcceso { get; set; }
        
        [Column("IP_ORIGEN")]
        public string? IpOrigen { get; set; }
        
        [Column("DISPOSITIVO")]
        public string? Dispositivo { get; set; }
        
        [Column("NAVEGADOR")]
        public string? Navegador { get; set; }
        
        [Column("SISTEMA_OPERATIVO")]
        public string? SistemaOperativo { get; set; }
        
        [Column("TIPO_ACCESO")]
        public string? TipoAcceso { get; set; }
        
        [Column("RESULTADO")]
        public string? Resultado { get; set; }
        
        [Column("SESION_ID")]
        public string? SesionId { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
