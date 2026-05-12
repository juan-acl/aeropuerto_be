using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RESERVAS")]
    public class ReservasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("CODIGO_RESERVA")]
        public string? CodigoReserva { get; set; }

        [Column("FECHA_RESERVA")]
        public DateTime? FechaReserva { get; set; }

        [Column("FECHA_MODIFICACION")]
        public DateTime? FechaModificacion { get; set; }

        [Column("ESTADO_RESERVA")]
        public string EstadoReserva { get; set; } = "CONFIRMADA";

        [Column("TIPO_TARIFA")]
        public string? TipoTarifa { get; set; }

        [Column("PRECIO_PAGADO")]
        public decimal PrecioPagado { get; set; }

        [Column("MONEDA")]
        public string? Moneda { get; set; }

        [Column("NUMERO_ASIENTO")]
        public string? NumeroAsiento { get; set; }

        [Column("CLASE_SERVICIO")]
        public string? ClaseServicio { get; set; }

        [Column("EQUIPAJE_FACTURADO_KG")]
        public decimal? EquipajeFacturadoKg { get; set; }

        [Column("EQUIPAJE_MANO_KG")]
        public decimal? EquipajeManoKg { get; set; }

        [Column("CHECKIN_REALIZADO")]
        public int CheckinRealizado { get; set; }

        [Column("FECHA_CHECKIN")]
        public DateTime? FechaCheckin { get; set; }

        [Column("PUERTA_EMBARQUE_ASIGNADA")]
        public string? PuertaEmbarqueAsignada { get; set; }

        [Column("GRUPO_EMBARQUE")]
        public int? GrupoEmbarque { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
