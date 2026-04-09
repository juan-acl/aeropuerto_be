using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TIENDAS_PRODUCTOS")]
    public class TiendasProductosModel
    {
        [Key]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [Column("ID_CONCESION")]
        public int? IdConcesion { get; set; }

        [Column("CODIGO_PRODUCTO")]
        public string? CodigoProducto { get; set; }

        [Column("NOMBRE_PRODUCTO")]
        public string? NombreProducto { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("CATEGORIA")]
        public string? Categoria { get; set; }

        [Column("PRECIO")]
        public decimal? Precio { get; set; }

        [Column("MONEDA")]
        public string? Moneda { get; set; }

        [Column("STOCK_ACTUAL")]
        public int? StockActual { get; set; }

        [Column("STOCK_MINIMO")]
        public int? StockMinimo { get; set; }

        [Column("IVA_APLICABLE")]
        public decimal? IvaAplicable { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}