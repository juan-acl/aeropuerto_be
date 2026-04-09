using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SALONES_ACCESOS")]
    public class SalonesAccesosModel
    {
        [Key]
        [Column("ID_ACCESO")]
        public int IdAcceso { get; set; }

        [Column("ID_SALON")]
        public int? IdSalon { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("FECHA_ACCESO")]
        public DateTime? FechaAcceso { get; set; }

        [Column("HORA_ENTRADA")]
        public DateTime? HoraEntrada { get; set; }

        [Column("HORA_SALIDA")]
        public DateTime? HoraSalida { get; set; }

        [Column("TIPO_ACCESO")]
        public string TipoAcceso { get; set; } = null!; // PRIMERA_CLASE, CLUB, PAGO, INVITACION

        [Column("COSTO")]
        public decimal? Costo { get; set; }

        [Column("AUTORIZADO_POR")]
        public string? AutorizadoPor { get; set; }
    }
}