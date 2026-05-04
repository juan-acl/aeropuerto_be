using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CHECKIN_DIGITAL")]
    public class CheckinDigitalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CHECKIN")]
        public int IdCheckin { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("FECHA_CHECKIN")]
        public DateTime? FechaCheckin { get; set; }

        [Column("IP_ORIGEN")]
        public string? IpOrigen { get; set; }

        [Column("DISPOSITIVO")]
        public string? Dispositivo { get; set; }

        [Column("PASE_ABORDAJE_GENERADO")]
        public int PaseAbordajeGenerado { get; set; } = 1;

        [Column("CODIGO_QR")]
        public byte[]? CodigoQr { get; set; }

        [Column("ENVIADO_EMAIL")]
        public int EnviadoEmail { get; set; } = 0;

        [Column("ENVIADO_SMS")]
        public int EnviadoSms { get; set; } = 0;
    }
}
