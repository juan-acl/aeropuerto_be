using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class EvaluacionDesempeno
    {
        [Key]
        public int IdEvaluacion { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public int EvaluadorId { get; set; }
        public string PeriodoEvaluado { get; set; } = null!;
        public decimal PuntuacionTotal { get; set; }
        public decimal PuntuacionProductividad { get; set; }
        public decimal PuntuacionCalidad { get; set; }
        public decimal PuntuacionAsistencia { get; set; }
        public decimal PuntuacionTrabajoEquipo { get; set; }
        public string Comentarios { get; set; } = null!;
        public string MetasFuturas { get; set; } = null!;
    }
}