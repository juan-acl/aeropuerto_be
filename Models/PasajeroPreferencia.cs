using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_PREFERENCIAS")]
    public class PasajeroPreferenciaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PREFERENCIA")]
        public int IdPreferencia { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("TIPO_PREFERENCIA")]
        public string TipoPreferencia { get; set; } = null!; // COMIDA, ASIENTO, etc.

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }
    }
}
