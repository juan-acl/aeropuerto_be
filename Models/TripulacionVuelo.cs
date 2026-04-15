using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("TRIPULACION_VUELO")]
    public class TripulacionVueloModel
    {
        [Key][Column("ID_ASIGNACION")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAsignacion { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("ID_TRIPULANTE")]
        public int IdTripulante { get; set; }
        [Column("ROL_EN_VUELO")][StringLength(30)]
        public string? RolEnVuelo { get; set; }   // PILOTO|COPILOTO|SOBRECARGO|AUXILIAR
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        [Column("CONFIRMADO")]
        public int Confirmado { get; set; } = 0;
    }
}
