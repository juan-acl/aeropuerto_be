using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class BodegaCarga
    {
        [Key]
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public decimal CapacidadMaxima { get; set; }
        public string TipoCarga { get; set; } = null!; // PERECEDEROS, PELIGROSA, GENERAL
    }
}