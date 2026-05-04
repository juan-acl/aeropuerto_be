using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDEN_COMPRA")]
    public class OrdenCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ORDEN")]
        public int IdOrden { get; set; }
        [Column("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }
        [Column("FECHA_ORDEN")]
        public DateTime FechaOrden { get; set; }
        [Column("TOTAL")]
        public decimal Total { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, RECIBIDA, CANCELADA
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
