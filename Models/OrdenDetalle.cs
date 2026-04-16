using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class OrdenDetalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdOrden { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}