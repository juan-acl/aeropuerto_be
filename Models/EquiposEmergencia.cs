using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EQUIPOS_EMERGENCIA")]
    public class EquiposEmergencia
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EQUIPO_EMERGENCIA")]
        public int IdEquipoEmergencia { get; set; }
        
        [Column("CODIGO_EQUIPO")]
        public string CodigoEquipo { get; set; } = null!;
        
        [Column("NOMBRE_EQUIPO")]
        public string NombreEquipo { get; set; } = null!;
        
        [Column("TIPO_EQUIPO")]
        public string? TipoEquipo { get; set; }
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("UBICACION_HABITUAL")]
        public string? UbicacionHabitual { get; set; }
        
        [Column("DISPONIBLE_24H")]
        public decimal? Disponible24h { get; set; }
        
        [Column("PERSONAL_ASIGNADO")]
        public decimal? PersonalAsignado { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("FECHA_ULTIMO_MANTENIMIENTO")]
        public DateTime? FechaUltimoMantenimiento { get; set; }
        
        [Column("FECHA_PROXIMO_MANTENIMIENTO")]
        public DateTime? FechaProximoMantenimiento { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
