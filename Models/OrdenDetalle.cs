using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDENES_DETALLE")]
    public class OrdenDetalle
    {
        [Key]
        [Column("ID_DETALLE")]
        public int id_detalle { get; set; }

        [Column("ID_ORDEN")]
        public int? id_orden { get; set; }

        [Column("DESCRIPCION")]
        public string? descripcion { get; set; }

        [Column("CANTIDAD")]
        public int? cantidad { get; set; }

        [Column("PRECIO_UNITARIO")]
        public decimal? precio_unitario { get; set; }

        [Column("SUBTOTAL_LINEA")]
        public decimal? subtotal_linea { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}