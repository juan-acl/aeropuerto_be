using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROHIBICIONES_VUELO")]
    public class ProhibicionesVueloModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PROHIBICION")]
        public int IdProhibicion { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("FECHA_PROHIBICION")]
        public DateTime? FechaProhibicion { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("MOTIVO")]
        public string? Motivo { get; set; }

        [Column("ID_INCIDENTE")]
        public int? IdIncidente { get; set; }

        [Column("AUTORIDAD_EMITE")]
        public string? AutoridadEmite { get; set; }

        [Column("ACTIVA")]
        public int Activa { get; set; } = 1;
    }
}
