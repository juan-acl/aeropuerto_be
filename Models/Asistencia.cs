using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ASISTENCIAS")]
    public class Asistencia
    {
        [Key]
        [Column("ID_ASISTENCIA")]
        public int id_asistencia { get; set; }

        [Column("ID_EMPLEADO")]
        public int? id_empleado { get; set; }

        [Column("FECHA")]
        public DateTime? fecha { get; set; }

        [Column("HORA_ENTRADA")]
        public DateTime? hora_entrada { get; set; }

        [Column("HORA_SALIDA")]
        public DateTime? hora_salida { get; set; }

        [Column("HORAS_TRABAJADAS")]
        public decimal? horas_trabajadas { get; set; }

        [Column("TIPO_JORNADA")]
        public string? tipo_jornada { get; set; } // ORDINARIA, EXTRA, NOCTURNA, FESTIVO

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }

        [Column("REGISTRADO_POR")]
        public int? registrado_por { get; set; }
    }
}