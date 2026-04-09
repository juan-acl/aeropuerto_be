using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("HISTORIAL_COMUNICACIONES")]
    public class HistorialComunicacionModel
    {
        [Key]
        [Column("ID_COMUNICACION")]
        public int IdComunicacion { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("TIPO_COMUNICACION")]
        public string TipoComunicacion { get; set; } = null!; // EMAIL, SMS, etc.

        [Column("FECHA_ENVIO")]
        public DateTime FechaEnvio { get; set; }

        [Column("ASUNTO")]
        public string? Asunto { get; set; }

        [Column("CONTENIDO")]
        public string? Contenido { get; set; }

        [Column("ESTADO")]
        public string? Estado { get; set; } // ENVIADO, LEIDO, etc.

        [Column("RESPUESTA_RECIBIDA")]
        public int RespuestaRecibida { get; set; } // 0 o 1
    }
}