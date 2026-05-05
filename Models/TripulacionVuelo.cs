using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Models
{
    [Table("TRIPULACION_VUELO")]
    [PrimaryKey(nameof(IdVuelo), nameof(IdTripulante))]
    public class TripulacionVueloModel
    {

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
