using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PERFILES_VIAJERO")]
    public class PerfilViajeroModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PERFIL")]
        public int IdPerfil { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("TIPO_PERFIL")]
        public string TipoPerfil { get; set; } = null!; // FRECUENTE, VIP, etc.

        [Column("NUMERO_PROGRAMA")]
        public string? NumeroPrograma { get; set; }

        [Column("AEROLINEA_ASOCIADA")]
        public int? AerolineaAsociada { get; set; }

        [Column("PUNTOS_ACUMULADOS")]
        public int PuntosAcumulados { get; set; }

        [Column("CATEGORIA")]
        public string? Categoria { get; set; }

        [Column("FECHA_INGRESO")]
        public DateTime? FechaIngreso { get; set; }

        [Column("FECHA_ULTIMA_ACTIVIDAD")]
        public DateTime? FechaUltimaActividad { get; set; }
    }
}
