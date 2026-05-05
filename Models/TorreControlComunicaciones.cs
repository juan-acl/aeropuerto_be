using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TORRE_CONTROL_COMUNICACIONES")]
    public class TorreControlComunicaciones
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_COMUNICACION_TORRE")]
        public decimal IdComunicacionTorre { get; set; }
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("TIMESTAMP_COMUNICACION")]
        public DateTime? TimestampComunicacion { get; set; }
        
        [Column("FRECUENCIA_MHZ")]
        public string? FrecuenciaMhz { get; set; }
        
        [Column("TIPO_COMUNICACION")]
        public string? TipoComunicacion { get; set; }
        
        [Column("ORIGEN")]
        public string? Origen { get; set; }
        
        [Column("DESTINO")]
        public string? Destino { get; set; }
        
        [Column("MENSAJE")]
        public string Mensaje { get; set; } = null!;
        
        [Column("OPERADOR_TORRE")]
        public decimal? OperadorTorre { get; set; }
        
        [Column("GRABACION_AUDIO")]
        public byte[]? GrabacionAudio { get; set; }
        
        [Column("TRANSCRITO")]
        public decimal? Transcrito { get; set; }
        
    }
}
