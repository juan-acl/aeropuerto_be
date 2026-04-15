using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ACTIVACIONES_EMERGENCIA")]
    public class ActivacionesEmergencia
    {
        
        [Key]
        [Column("ID_ACTIVACION")]
        public int IdActivacion { get; set; }
        
        [Column("FECHA_HORA_ACTIVACION")]
        public DateTime? FechaHoraActivacion { get; set; }
        
        [Column("TIPO_EMERGENCIA")]
        public string TipoEmergencia { get; set; } = null!;
        
        [Column("ID_PLAN_EMERGENCIA")]
        public decimal? IdPlanEmergencia { get; set; }
        
        [Column("NIVEL_ACTIVACION")]
        public string? NivelActivacion { get; set; }
        
        [Column("DESCRIPCION_INCIDENTE")]
        public string DescripcionIncidente { get; set; } = null!;
        
        [Column("LUGAR_INCIDENTE")]
        public string? LugarIncidente { get; set; }
        
        [Column("PERSONAS_AFECTADAS")]
        public decimal? PersonasAfectadas { get; set; }
        
        [Column("PERSONAS_ATENDIDAS")]
        public decimal? PersonasAtendidas { get; set; }
        
        [Column("RECURSOS_MOVILIZADOS")]
        public string? RecursosMovilizados { get; set; }
        
        [Column("HORA_CONTROL")]
        public DateTime? HoraControl { get; set; }
        
        [Column("HORA_FIN")]
        public DateTime? HoraFin { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("RESPONSABLE_COORDINACION")]
        public string? ResponsableCoordinacion { get; set; }
        
        [Column("INFORME_INCIDENTE")]
        public string? InformeIncidente { get; set; }
        
        [Column("LECCIONES_APRENDIDAS")]
        public string? LeccionesAprendidas { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
