using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ACOMPANANTES_VIAJE")]
    public class AcompanantesViajeModel
    {
        [Key]
        [Column("ID_ACOMPANANTE")]
        public int IdAcompanante { get; set; }

        [Column("ID_PASAJERO_PRINCIPAL")]
        public int IdPasajeroPrincipal { get; set; }

        [Column("ID_PASAJERO_ACOMPANANTE")]
        public int IdPasajeroAcompanante { get; set; }

        [Column("FRECUENCIA")]
        public int Frecuencia { get; set; }

        [Column("RELACION")]
        public string Relacion { get; set; } = null!; // FAMILIAR, AMIGO, COLEGA

        [Column("ULTIMO_VIAJE_JUNTOS")]
        public DateTime? UltimoViajeJuntos { get; set; }
    }
}