using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ESTACIONAMIENTO_REGISTRO")]
    public class EstacionamientoRegistroModel
    {
        [Key]
        [Column("ID_REGISTRO")]
        public int IdRegistro { get; set; }

        [Column("ID_ESPACIO")]
        public int? IdEspacio { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("PLACA_VEHICULO")]
        public string? PlacaVehiculo { get; set; }

        [Column("FECHA_ENTRADA")]
        public DateTime? FechaEntrada { get; set; }

        [Column("FECHA_SALIDA")]
        public DateTime? FechaSalida { get; set; }

        [Column("TIEMPO_TOTAL_HORAS")]
        public decimal? TiempoTotalHoras { get; set; }

        [Column("TARIFA_APLICADA")]
        public decimal? TarifaAplicada { get; set; }

        [Column("TOTAL_PAGAR")]
        public decimal? TotalPagar { get; set; }

        [Column("ESTADO_PAGO")]
        public int EstadoPago { get; set; } = 0; // 0 = Pendiente, 1 = Pagado

        [Column("METODO_PAGO")]
        public string? MetodoPago { get; set; }
    }
}