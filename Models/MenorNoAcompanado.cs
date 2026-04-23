using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MENOR_NO_ACOMPANADO")]
    public class MenorNoAcompanado
    {
        [Key]
        [Column("ID_SERVICIO_MENOR")]
        public int IdServicioMenor { get; set; }
        [Column("ID_PASAJERO_MENOR")]
        public int IdPasajeroMenor { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("PERSONA_ENTREGA")]
        public string PersonaEntrega { get; set; } = null!;
        [Column("PERSONA_RECIBE")]
        public string PersonaRecibe { get; set; } = null!;
        [Column("TELEFONO_CONTACTO")]
        public string TelefonoContacto { get; set; } = null!;
        [Column("ESTADO_SERVICIO")]
        public string EstadoServicio { get; set; } = "PENDIENTE";
    }
}