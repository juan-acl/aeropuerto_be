using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("FACTURACION_COMBUSTIBLE")]
    public class FacturacionCombustible
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_FACTURA_COMBUSTIBLE")]
        public int IdFacturaCombustible { get; set; }
        
        [Column("ID_CARGA_COMBUSTIBLE")]
        public decimal IdCargaCombustible { get; set; }
        
        [Column("NUMERO_FACTURA")]
        public string NumeroFactura { get; set; } = null!;
        
        [Column("ID_AEROLINEA")]
        public decimal IdAerolinea { get; set; }
        
        [Column("FECHA_EMISION")]
        public DateTime? FechaEmision { get; set; }
        
        [Column("CANTIDAD_LITROS")]
        public decimal? CantidadLitros { get; set; }
        
        [Column("PRECIO_UNITARIO")]
        public decimal? PrecioUnitario { get; set; }
        
        [Column("SUBTOTAL")]
        public decimal? Subtotal { get; set; }
        
        [Column("IMPUESTOS")]
        public decimal? Impuestos { get; set; }
        
        [Column("TOTAL")]
        public decimal? Total { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("PAGADA")]
        public decimal? Pagada { get; set; }
        
        [Column("FECHA_PAGO")]
        public DateTime? FechaPago { get; set; }
        
        [Column("FORMA_PAGO")]
        public string? FormaPago { get; set; }
        
    }
}
