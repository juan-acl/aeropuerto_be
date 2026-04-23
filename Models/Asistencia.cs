using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ASISTENCIA")]
    public class Asistencia
    {
        [Key]
        [Column("ID_ASISTENCIA")]
        public int IdAsistencia { get; set; }
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("HORA_ENTRADA")]
        public DateTime HoraEntrada { get; set; }
        [Column("HORA_SALIDA")]
        public DateTime HoraSalida { get; set; }
        [Column("HORAS_TRABAJADAS")]
        public decimal HorasTrabajadas { get; set; }
        [Column("TIPO_JORNADA")]
        public string TipoJornada { get; set; } = null!; // ORDINARIA, EXTRA, etc.
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        [Column("REGISTRADO_POR")]
        public int RegistradoPor { get; set; }
    }
}