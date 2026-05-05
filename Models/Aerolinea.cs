using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("AEROLINEAS")]  
    public class AerolineaModel
    {
        [Key]
        [Column("ID_AEROLINEA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAerolinea { get; set; }

        [Column("NOMBRE_AEROLINEA")]
        [Required]
        [StringLength(100)]
        public string NombreAerolinea { get; set; } = null!;

        [Column("CODIGO_IATA")]
        [StringLength(5)]
        public string? CodigoIata { get; set; }

        [Column("CODIGO_OACI")]
        [StringLength(5)]
        public string? CodigoOaci { get; set; }

        [Column("PAIS_ORIGEN")]
        [StringLength(50)]
        public string? PaisOrigen { get; set; }

        [Column("ANIO_FUNDACION")]
        public int? AnioFundacion { get; set; }

        [Column("FLOTA_TOTAL")]
        public int? FlotaTotal { get; set; }

        [Column("DESTINOS_TOTALES")]
        public int? DestinosTotales { get; set; }

        [Column("ALIANZA")]
        [StringLength(30)]
        public string? Alianza { get; set; } // Valores: STAR_ALLIANCE, SKYTEAM, ONEWORLD, NINGUNA

        [Column("WEBSITE")]
        [StringLength(100)]
        public string? Website { get; set; }

        [Column("TELEFONO_CONTACTO")]
        [StringLength(20)]
        public string? TelefonoContacto { get; set; }

        [Column("EMAIL_CONTACTO")]
        [StringLength(100)]
        public string? EmailContacto { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;

        [Column("FECHA_REGISTRO")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
