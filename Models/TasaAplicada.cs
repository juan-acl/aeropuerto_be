using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class TasaAplicada
    {
        [Key]
        public int IdAplicacion { get; set; }
        public int IdTasa { get; set; }
        public int IdPasajero { get; set; }
        public int IdVuelo { get; set; }
        public DateTime FechaCobro { get; set; }
        public decimal MontoCobrado { get; set; }
        public string Estado { get; set; } = "PAGADO";
    }
}