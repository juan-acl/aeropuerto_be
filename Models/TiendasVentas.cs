using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TIENDAS_VENTAS")]
    public class TiendasVentasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_VENTA")]
        public int IdVenta { get; set; }

        [Column("ID_CONCESION")]
        public int? IdConcesion { get; set; }

        [Column("FECHA_VENTA")]
        public DateTime? FechaVenta { get; set; }

        [Column("ID_RESERVA")]
        public int? IdReserva { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("TIPO_CLIENTE")]
        public string TipoCliente { get; set; } = "PASAJERO"; // PASAJERO, VISITANTE, TRIPULANTE

        [Column("SUBTOTAL")]
        public decimal? Subtotal { get; set; }

        [Column("IMPUESTOS")]
        public decimal? Impuestos { get; set; }

        [Column("TOTAL")]
        public decimal? Total { get; set; }

        [Column("METODO_PAGO")]
        public string? MetodoPago { get; set; }

        [Column("TARJETA_NUMERO")]
        public string? TarjetaNumero { get; set; }

        [Column("AUTORIZADO_POR")]
        public string? AutorizadoPor { get; set; }
    }
}
