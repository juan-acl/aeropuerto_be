using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TEMPORADAS_VUELO")]
    public class TemporadaVueloModel
    {
        [Key]
        [Column("ID_TEMPORADA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTemporada { get; set; }

        [Column("NOMBRE_TEMPORADA")]
        [StringLength(50)]
        public string? NombreTemporada { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("FACTOR_DEMANDA")]
        [Range(0.5, 2.0)]
        public decimal? FactorDemanda { get; set; }

        [Column("ACTIVA")]
        public int Activa { get; set; } = 1;
    }
}