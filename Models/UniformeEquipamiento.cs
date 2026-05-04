using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("UNIFORME_EQUIPAMIENTO")]
    public class UniformeEquipamiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ASIGNACION")]
        public int IdAsignacion { get; set; }
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("TIPO_EQUIPO")]
        public string TipoEquipo { get; set; } = null!; // UNIFORME, RADIO, COMPUTADORA, etc.
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("TALLA")]
        public string Talla { get; set; } = null!;
        [Column("FECHA_ASIGNACION")]
        public DateTime FechaAsignacion { get; set; }
        [Column("FECHA_DEVOLUCION")]
        public DateTime? FechaDevolucion { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "NUEVO";
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
