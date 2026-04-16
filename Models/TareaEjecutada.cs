using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class TareaEjecutada
    {
        [Key]
        public int IdTareaEjecutada { get; set; }
        public int IdEjecucion { get; set; }
        public string DescripcionTarea { get; set; } = null!;
        public string Resultado { get; set; } = null!; // OK, FALLO, REPARADO
        public string? Hallazgos { get; set; }
    }
}