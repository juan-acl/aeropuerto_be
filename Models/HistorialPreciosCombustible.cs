using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("HISTORIAL_PRECIOS_COMBUSTIBLE")]
    public class HistorialPreciosCombustible
    {
        
        [Key]
        [Column("ID_PRECIO_COMBUSTIBLE")]
        public int IdPrecioCombustible { get; set; }
        
        [Column("FECHA_PRECIO")]
        public DateTime FechaPrecio { get; set; }
        
        [Column("TIPO_COMBUSTIBLE")]
        public string TipoCombustible { get; set; } = null!;
        
        [Column("PRECIO_COMPRA_LOCAL")]
        public decimal? PrecioCompraLocal { get; set; }
        
        [Column("PRECIO_VENTA_AEROLINEAS")]
        public decimal? PrecioVentaAerolineas { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("PRECIO_INTERNACIONAL_REFERENCIA")]
        public decimal? PrecioInternacionalReferencia { get; set; }
        
        [Column("VARIACION_PORCENTUAL")]
        public decimal? VariacionPorcentual { get; set; }
        
        [Column("FACTOR_AJUSTE")]
        public decimal? FactorAjuste { get; set; }
        
        [Column("VIGENTE")]
        public decimal? Vigente { get; set; }
    }
}
