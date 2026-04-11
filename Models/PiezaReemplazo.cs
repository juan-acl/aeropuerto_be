using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class PiezaReemplazo
    {
        [Key]
        public int IdPieza { get; set; }
        public string NombrePieza { get; set; } = null!;
        public string NumeroParte { get; set; } = null!;
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}