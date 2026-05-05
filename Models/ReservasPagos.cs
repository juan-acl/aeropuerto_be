using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RESERVAS_PAGOS")]
    public class ReservasPagosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PAGO")]
        public int IdPago { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("ID_METODO_PAGO")]
        public int IdMetodoPago { get; set; }

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("MONEDA")]
        public string Moneda { get; set; } = "USD";

        [Column("FECHA_PAGO")]
        public DateTime? FechaPago { get; set; }

        [Column("CODIGO_TRANSACCION")]
        public string? CodigoTransaccion { get; set; }

        [Column("ESTADO_PAGO")]
        public string EstadoPago { get; set; } = "COMPLETADO";

        [Column("COMPROBANTE_PAGO")]
        public byte[]? ComprobantePago { get; set; }
    }
}
