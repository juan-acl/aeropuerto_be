using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("EMPLEADOS_CAPACITACION")]
    public class EmpleadoCapacitacion
    {
        [Column("ID_EMPLEADO")]
        public int id_empleado { get; set; }

        [Column("ID_CAPACITACION")]
        public int id_capacitacion { get; set; }

        [Column("FECHA_ASIGNACION")]
        public DateTime? fecha_asignacion { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; }

        [Column("FECHA_COMPLETADO")]
        public DateTime? fecha_completado { get; set; }

        [Column("CALIFICACION")]
        public decimal? calificacion { get; set; }

        [Column("CERTIFICADO_OBTENIDO")]
        public int? certificado_obtenido { get; set; }
    }
}