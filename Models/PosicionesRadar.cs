using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("POSICIONES_RADAR")]
    public class PosicionesRadar
    {
        
        [Key]
        [Column("ID_POSICION_RADAR")]
        public decimal IdPosicionRadar { get; set; }
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("TIMESTAMP_POSICION")]
        public DateTime? TimestampPosicion { get; set; }
        
        [Column("LATITUD")]
        public decimal? Latitud { get; set; }
        
        [Column("LONGITUD")]
        public decimal? Longitud { get; set; }
        
        [Column("ALTITUD_PIES")]
        public decimal? AltitudPies { get; set; }
        
        [Column("VELOCIDAD_NUDOS")]
        public decimal? VelocidadNudos { get; set; }
        
        [Column("HEADING_GRADOS")]
        public decimal? HeadingGrados { get; set; }
        
        [Column("TASA_ASCENSO")]
        public decimal? TasaAscenso { get; set; }
        
        [Column("FUENTE_DATOS")]
        public string? FuenteDatos { get; set; }
        
        [Column("PRECISION_POSICION")]
        public decimal? PrecisionPosicion { get; set; }
        
        [Column("PROCESADO")]
        public decimal? Procesado { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
