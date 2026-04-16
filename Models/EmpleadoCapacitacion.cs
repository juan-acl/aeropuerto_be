using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    public class EmpleadoCapacitacion
    {
        public int IdEmpleado { get; set; }
        public int IdCapacitacion { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Estado { get; set; } = "INSCRITO";
        public DateTime? FechaCompletado { get; set; }
        public decimal? Calificacion { get; set; }
        public int CertificadoObtenido { get; set; } = 0; // 0 = No, 1 = Sí
    }
}