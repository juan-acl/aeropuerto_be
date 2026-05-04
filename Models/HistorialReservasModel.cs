using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("HISTORIAL_RESERVAS")]
    public class HistorialReservasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_HISTORIAL_RESERVA")]
        public int IdHistorialReserva { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("FECHA_CAMBIO")]
        public DateTime? FechaCambio { get; set; }

        [Column("CAMPO_MODIFICADO")]
        public string? CampoModificado { get; set; }

        [Column("VALOR_ANTERIOR")]
        public string? ValorAnterior { get; set; }

        [Column("VALOR_NUEVO")]
        public string? ValorNuevo { get; set; }

        [Column("USUARIO_MODIFICACION")]
        public string? UsuarioModificacion { get; set; }

        [Column("MOTIVO_CAMBIO")]
        public string? MotivoCambio { get; set; }
    }
}
