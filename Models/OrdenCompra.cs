using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class OrdenCompra
    {
        [Key]
        public int IdOrden { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, RECIBIDA, CANCELADA
        public string? Observaciones { get; set; }
    }
}