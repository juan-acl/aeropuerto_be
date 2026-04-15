using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PERSONAL_EMERGENCIA")]
    public class PersonalEmergencia
    {
        
        [Key]
        [Column("ID_PERSONAL_EMERGENCIA")]
        public int IdPersonalEmergencia { get; set; }
        
        [Column("ID_EMPLEADO")]
        public decimal? IdEmpleado { get; set; }
        
        [Column("ESPECIALIDAD")]
        public string? Especialidad { get; set; }
        
        [Column("NIVEL_CERTIFICACION")]
        public string? NivelCertificacion { get; set; }
        
        [Column("FECHA_CERTIFICACION")]
        public DateTime? FechaCertificacion { get; set; }
        
        [Column("FECHA_VENCIMIENTO_CERTIFICACION")]
        public DateTime? FechaVencimientoCertificacion { get; set; }
        
        [Column("DISPONIBLE_24H")]
        public decimal? Disponible24h { get; set; }
        
        [Column("GRUPO_RESPUESTA")]
        public string? GrupoRespuesta { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
