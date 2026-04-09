using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ENCUESTAS_SATISFACCION")]
    public class EncuestasSatisfaccionModel
    {
        [Key]
        [Column("ID_ENCUESTA")]
        public int IdEncuesta { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("FECHA_ENCUESTA")]
        public DateTime? FechaEncuesta { get; set; }

        [Column("PUNTUACION_GENERAL")]
        public int? PuntuacionGeneral { get; set; }

        [Column("PUNTUACION_CHECKIN")]
        public int? PuntuacionCheckin { get; set; }

        [Column("PUNTUACION_ABORDAJE")]
        public int? PuntuacionAbordaje { get; set; }

        [Column("PUNTUACION_COMODIDAD")]
        public int? PuntuacionComodidad { get; set; }

        [Column("PUNTUACION_LIMPIEZA")]
        public int? PuntuacionLimpieza { get; set; }

        [Column("PUNTUACION_ATENCION")]
        public int? PuntuacionAtencion { get; set; }

        [Column("PUNTUACION_EQUIPAJE")]
        public int? PuntuacionEquipaje { get; set; }

        [Column("COMENTARIOS")]
        public string? Comentarios { get; set; }

        [Column("RECOMIENDA")]
        public int Recomienda { get; set; } = 1; // 1 = Sí, 0 = No
    }
}