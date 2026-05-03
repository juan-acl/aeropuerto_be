using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PROVEEDORES_REPUESTOS")]
    public class ProveedorRepuesto
    {
        [Key]
        [Column("ID_PROVEEDOR_REPUESTO")]
        public int id_proveedor_repuesto { get; set; }

        [Column("ID_PROVEEDOR")]
        public int? id_proveedor { get; set; }

        [Column("ID_PIEZA")]
        public int? id_pieza { get; set; }

        [Column("PRECIO_CONTRATO")]
        public decimal? precio_contrato { get; set; }

        [Column("TIEMPO_ENTREGA_DIAS")]
        public int? tiempo_entrega_dias { get; set; }

        [Column("CALIFICACION")]
        public int? calificacion { get; set; }

        [Column("ULTIMA_COMPRA")]
        public DateTime? ultima_compra { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}