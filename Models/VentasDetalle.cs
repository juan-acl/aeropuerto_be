using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("VENTAS_DETALLE")]
    public class VentasDetalleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DETALLE")]
        public int IdDetalle { get; set; }

        [Column("ID_VENTA")]
        public int? IdVenta { get; set; }

        [Column("ID_PRODUCTO")]
        public int? IdProducto { get; set; }

        [Column("CANTIDAD")]
        public int? Cantidad { get; set; }

        [Column("PRECIO_UNITARIO")]
        public decimal? PrecioUnitario { get; set; }

        [Column("DESCUENTO_APLICADO")]
        public decimal? DescuentoAplicado { get; set; }

        [Column("SUBTOTAL_LINEA")]
        public decimal? SubtotalLinea { get; set; }
    }
}
