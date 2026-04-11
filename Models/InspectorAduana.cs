using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class InspectorAduana
    {
        [Key]
        public int IdInspector { get; set; }
        public string Nombre { get; set; } = null!;
        public string Credencial { get; set; } = null!;
        public string Turno { get; set; } = null!;
        public int Activo { get; set; } = 1;
    }
}