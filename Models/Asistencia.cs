using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Asistencia
    {
        [Key]
        public int IdAsistencia { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public string TipoJornada { get; set; } = null!; // ORDINARIA, EXTRA, etc.
        public string? Observaciones { get; set; }
        public int RegistradoPor { get; set; }
    }
}