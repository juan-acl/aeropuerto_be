using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("GRUPOS_PASAJEROS")]
    public class GruposPasajerosModel
    {
        [Key]
        [Column("ID_GRUPO", Order = 0)]
        public int IdGrupo { get; set; }

        [Column("ID_PASAJERO", Order = 1)]
        public int IdPasajero { get; set; }

        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }

        [Column("ROL_EN_GRUPO")]
        public string? RolEnGrupo { get; set; } // Ejemplo: LIDER, MIEMBRO, GUIA
    }
}
