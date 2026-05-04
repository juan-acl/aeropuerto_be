using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EMPLEADOS_CAPACITACION")]
    public class EmpleadoCapacitacion
    {
        [Key]
        [Column("ID_EMPLEADO", Order = 0)]
        public int IdEmpleado { get; set; }

        [Column("ID_CAPACITACION", Order = 1)]
        public int IdCapacitacion { get; set; }

        [Column("FECHA_ASIGNACION")]
        public DateTime FechaAsignacion { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "INSCRITO";

        [Column("FECHA_COMPLETADO")]
        public DateTime? FechaCompletado { get; set; }

        [Column("CALIFICACION")]
        public decimal? Calificacion { get; set; }

        [Column("CERTIFICADO_OBTENIDO")]
        public int CertificadoObtenido { get; set; } = 0; // 0 = No, 1 = Sí
    }
}
