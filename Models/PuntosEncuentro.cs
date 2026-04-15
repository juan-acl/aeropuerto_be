using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PUNTOS_ENCUENTRO")]
    public class PuntosEncuentro
    {
        
        [Key]
        [Column("ID_PUNTO_ENCUENTRO")]
        public int IdPuntoEncuentro { get; set; }
        
        [Column("CODIGO_PUNTO")]
        public string CodigoPunto { get; set; } = null!;
        
        [Column("NOMBRE")]
        public string Nombre { get; set; } = null!;
        
        [Column("UBICACION")]
        public string Ubicacion { get; set; } = null!;
        
        [Column("COORDENADA_LATITUD")]
        public decimal? CoordenadaLatitud { get; set; }
        
        [Column("COORDENADA_LONGITUD")]
        public decimal? CoordenadaLongitud { get; set; }
        
        [Column("CAPACIDAD_PERSONAS")]
        public decimal? CapacidadPersonas { get; set; }
        
        [Column("SENALIZACION_VISIBLE")]
        public decimal? SenalizacionVisible { get; set; }
        
        [Column("ILUMINACION")]
        public decimal? Iluminacion { get; set; }
        
        [Column("RECURSOS_DISPONIBLES")]
        public string? RecursosDisponibles { get; set; }
        
        [Column("RESPONSABLE_ASIGNADO")]
        public string? ResponsableAsignado { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
