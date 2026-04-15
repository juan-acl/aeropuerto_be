using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TRIPULACION")]
    public class TripulacionModel
    {
        [Key]
        [Column("ID_TRIPULANTE")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTripulante { get; set; }

        [Column("NOMBRES")]
        [StringLength(100)]
        public string? Nombres { get; set; }

        [Column("APELLIDOS")]
        [StringLength(100)]
        public string? Apellidos { get; set; }

        [Column("TIPO_DOCUMENTO")]
        [StringLength(20)]
        public string? TipoDocumento { get; set; }

        [Column("NUMERO_DOCUMENTO")]
        [StringLength(30)]
        public string? NumeroDocumento { get; set; }

        [Column("FECHA_NACIMIENTO")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("NACIONALIDAD")]
        [StringLength(50)]
        public string? Nacionalidad { get; set; }

        [Column("TIPO_TRIPULANTE")]
        [StringLength(30)]
        public string? TipoTripulante { get; set; }

        [Column("LICENCIA")]
        [StringLength(50)]
        public string? Licencia { get; set; }

        [Column("FECHA_LICENCIA")]
        public DateTime? FechaLicencia { get; set; }

        [Column("FECHA_VENCIMIENTO_LICENCIA")]
        public DateTime? FechaVencimientoLicencia { get; set; }

        [Column("HORAS_VUELO_ACUMULADAS")]
        public decimal? HorasVueloAcumuladas { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}