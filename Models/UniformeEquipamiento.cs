using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("UNIFORMES_EQUIPAMIENTO")]
    public class UniformeEquipamiento
    {
        [Key]
        [Column("ID_ASIGNACION")]
        public int id_asignacion { get; set; }

        [Column("ID_EMPLEADO")]
        public int? id_empleado { get; set; }

        [Column("TIPO_EQUIPO")]
        public string? tipo_equipo { get; set; } // UNIFORME, RADIO, COMPUTADORA, HERRAMIENTA, CHALECO

        [Column("DESCRIPCION")]
        public string? descripcion { get; set; }

        [Column("TALLA")]
        public string? talla { get; set; }

        [Column("FECHA_ASIGNACION")]
        public DateTime? fecha_asignacion { get; set; }

        [Column("FECHA_DEVOLUCION")]
        public DateTime? fecha_devolucion { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; } // NUEVO, BUENO, REGULAR, MALO

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}