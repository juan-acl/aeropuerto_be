using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("FACTURAS")]
    public class FacturasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_FACTURA")]
        public int IdFactura { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("NUMERO_FACTURA")]
        public string? NumeroFactura { get; set; }

        [Column("FECHA_EMISION")]
        public DateTime? FechaEmision { get; set; }

        [Column("SUBTOTAL")]
        public decimal Subtotal { get; set; }

        [Column("IMPUESTOS")]
        public decimal Impuestos { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }

        [Column("MONEDA")]
        public string Moneda { get; set; } = "USD";

        [Column("DATOS_FISCALES")]
        public string? DatosFiscales { get; set; }

        [Column("PDF_FACTURA")]
        public byte[]? PdfFactura { get; set; }
    }
}
