using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CONTROL_ABORDAJE")]
    public class ControlAbordajeModel
    {
        [Key]
        [Column("ID_CONTROL_ABORDAJE")]
        public int IdControlAbordaje { get; set; }

        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("HORA_ABORDAJE")]
        public DateTime? HoraAbordaje { get; set; }

        [Column("VERIFICADO_POR")]
        public int VerificadoPor { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "ABORDADO"; // ABORDADO, NO_ABORDADO

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}