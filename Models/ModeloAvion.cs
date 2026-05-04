using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MODELOS_AVIONES")] 
    public class ModeloAvionModel
    {
        [Key]
        [Column("ID_MODELO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModelo { get; set; }

        [Column("NOMBRE_MODELO")]
        [Required]
        [StringLength(50)]
        public string NombreModelo { get; set; } = null!;

        [Column("FABRICANTE")]
        [StringLength(50)]
        public string? Fabricante { get; set; }

        [Column("CAPACIDAD_PASAJEROS")]
        [Required]
        public int CapacidadPasajeros { get; set; }

        [Column("CAPACIDAD_CARGA_KG")]
        public decimal? CapacidadCargaKg { get; set; }

        [Column("AUTONOMIA_KM")]
        public decimal? AutonomiaKm { get; set; }

        [Column("VELOCIDAD_CRUCERO_KMH")]
        public decimal? VelocidadCruceroKmh { get; set; }

        [Column("LONGITUD_METROS")]
        public decimal? LongitudMetros { get; set; }

        [Column("ENVERGADURA_METROS")]
        public decimal? EnvergaduraMetros { get; set; }

        [Column("ALTURA_METROS")]
        public decimal? AlturaMetros { get; set; }

        [Column("TRIPULACION_MINIMA")]
        public int? TripulacionMinima { get; set; }

        [Column("ANIO_FABRICACION")]
        public int? AnioFabricacion { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
