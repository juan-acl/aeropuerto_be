using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("QUEJAS_SUGERENCIAS")]
    public class QuejasSugerenciasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_QUEJA")]
        public int IdQueja { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("TIPO_CONTACTO")]
        public string TipoContacto { get; set; } = null!; // QUEJA, SUGERENCIA, FELICITACION, RECLAMO

        [Column("FECHA_CONTACTO")]
        public DateTime? FechaContacto { get; set; }

        [Column("MEDIO_RECEPCION")]
        public string MedioRecepcion { get; set; } = null!; // WEB, APP, PRESENCIAL, TELEFONICO, EMAIL

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("AREA_RELACIONADA")]
        public string? AreaRelacionada { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "RECIBIDO"; // RECIBIDO, EN_PROCESO, RESPONDIDO, CERRADO

        [Column("FECHA_RESPUESTA")]
        public DateTime? FechaRespuesta { get; set; }

        [Column("RESPUESTA")]
        public string? Respuesta { get; set; }

        [Column("SATISFACCION_RESPUESTA")]
        public int? SatisfaccionRespuesta { get; set; } // Ejemplo: 1 al 5
    }
}
