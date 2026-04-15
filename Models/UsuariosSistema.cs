using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("USUARIOS_SISTEMA")]
    public class UsuariosSistema
    {
        
        [Key]
        [Column("ID_USUARIO_SISTEMA")]
        public int IdUsuarioSistema { get; set; }
        
        [Column("ID_EMPLEADO")]
        public decimal? IdEmpleado { get; set; }
        
        [Column("NOMBRE_USUARIO")]
        public string NombreUsuario { get; set; } = null!;
        
        [Column("PASSWORD_HASH")]
        public string PasswordHash { get; set; } = null!;
        
        [Column("EMAIL_INSTITUCIONAL")]
        public string? EmailInstitucional { get; set; }
        
        [Column("FECHA_CREACION")]
        public DateTime? FechaCreacion { get; set; }
        
        [Column("FECHA_ULTIMO_ACCESO")]
        public DateTime? FechaUltimoAcceso { get; set; }
        
        [Column("FECHA_VENCIMIENTO_PASSWORD")]
        public DateTime? FechaVencimientoPassword { get; set; }
        
        [Column("INTENTOS_FALLIDOS")]
        public decimal? IntentosFallidos { get; set; }
        
        [Column("BLOQUEADO")]
        public decimal? Bloqueado { get; set; }
        
        [Column("MOTIVO_BLOQUEO")]
        public string? MotivoBloqueo { get; set; }
        
        [Column("REQUIERE_CAMBIO_PASSWORD")]
        public decimal? RequiereCambioPassword { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
        [Column("CREADO_POR")]
        public decimal? CreadoPor { get; set; }

    }
}
