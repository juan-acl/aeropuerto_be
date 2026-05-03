using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ORDENES_COMPRA")]
    public class OrdenCompra
    {
        [Key]
        [Column("ID_ORDEN")]
        public int id_orden { get; set; }

        [Column("ID_PROVEEDOR")]
        public int? id_proveedor { get; set; }

        [Column("FECHA_ORDEN")]
        public DateTime? fecha_orden { get; set; }

        [Column("FECHA_ENTREGA_ESTIMADA")]
        public DateTime? fecha_entrega_estimada { get; set; }

        [Column("FECHA_ENTREGA_REAL")]
        public DateTime? fecha_entrega_real { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; } // PENDIENTE por defecto

        [Column("SUBTOTAL")]
        public decimal? subtotal { get; set; }

        [Column("IMPUESTOS")]
        public decimal? impuestos { get; set; }

        [Column("TOTAL")]
        public decimal? total { get; set; }

        [Column("CONDICIONES_ENTREGA")]
        public string? condiciones_entrega { get; set; }

        [Column("SOLICITADO_POR")]
        public int? solicitado_por { get; set; }

        [Column("AUTORIZADO_POR")]
        public int? autorizado_por { get; set; }
    }
}