using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDEN_DETALLE")]
    public class OrdenDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DETALLE")]
        public int IdDetalle { get; set; }
        [Column("ID_ORDEN")]
        public int IdOrden { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("PRECIO_UNITARIO")]
        public decimal PrecioUnitario { get; set; }
        [Column("SUBTOTAL")]
        public decimal Subtotal { get; set; }
    }
}
