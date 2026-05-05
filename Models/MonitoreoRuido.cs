using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MONITOREO_RUIDO")]
    public class MonitoreoRuido
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MEDICION_RUIDO")]
        public int IdMedicionRuido { get; set; }
        
        [Column("ID_ESTACION_AMBIENTAL")]
        public decimal IdEstacionAmbiental { get; set; }
        
        [Column("FECHA_HORA_MEDICION")]
        public DateTime? FechaHoraMedicion { get; set; }
        
        [Column("NIVEL_RUIDO_CONTINUA_DB")]
        public decimal? NivelRuidoContinuaDb { get; set; }
        
        [Column("NIVEL_RUIDO_MAXIMO_DB")]
        public decimal? NivelRuidoMaximoDb { get; set; }
        
        [Column("NIVEL_RUIDO_MINIMO_DB")]
        public decimal? NivelRuidoMinimoDb { get; set; }
        
        [Column("FRECUENCIA_HZ")]
        public string? FrecuenciaHz { get; set; }
        
        [Column("DURACION_SEGUNDOS")]
        public decimal? DuracionSegundos { get; set; }
        
        [Column("ID_VUELO_ASOCIADO")]
        public decimal? IdVueloAsociado { get; set; }
        
        [Column("TIPO_FUENTE")]
        public string? TipoFuente { get; set; }
        
        [Column("EXCEDE_LIMITE")]
        public decimal? ExcedeLimite { get; set; }
        
        [Column("ALERTA_GENERADA")]
        public decimal? AlertaGenerada { get; set; }
        

    }
}
