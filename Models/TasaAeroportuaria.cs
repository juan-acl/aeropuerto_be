using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class TasaAeroportuaria
    {
        [Key]
        public int IdTasa { get; set; }
        public string NombreTasa { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string TipoTasa { get; set; } = null!; // NACIONAL, INTERNACIONAL
        public int Activo { get; set; } = 1;
    }
}