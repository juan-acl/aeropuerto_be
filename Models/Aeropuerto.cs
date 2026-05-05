using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("AEROPUERTOS")] 
    public class AeropuertoModel
    {
        [Key]
        [Column("CODIGO_AEROPUERTO")]
        public string CodigoAeropuerto { get; set; } = null!;

        [Column("NOMBRE")]
        public string Nombre { get; set; } = null!;

        [Column("CIUDAD")]
        public string Ciudad { get; set; } = null!;

        [Column("PAIS")]
        public string Pais { get; set; } = null!;

        [Column("REGION")]
        public string? Region { get; set; }

        [Column("CONTINENTE")]
        public string? Continente { get; set; }

        [Column("HUSO_HORARIO")]
        public string? HusoHorario { get; set; }

        [Column("LATITUD")]
        public decimal? Latitud { get; set; }

        [Column("LONGITUD")]
        public decimal? Longitud { get; set; }

        [Column("ELEVACION_METROS")]
        public decimal? ElevacionMetros { get; set; }

        [Column("TERMINALES")]
        public int? Terminales { get; set; }

        [Column("PUERTAS_ABORDAJE")]
        public int? PuertasAbordaje { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime FechaRegistro { get; set; }

        [Column("USUARIO_REGISTRO")]
        public string? UsuarioRegistro { get; set; }
    }
}
