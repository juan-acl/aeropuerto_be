using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MONITOREO_AIRE")]
    public class MonitoreoAire
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MEDICION_AIRE")]
        public decimal IdMedicionAire { get; set; }
        
        [Column("ID_ESTACION_AMBIENTAL")]
        public decimal IdEstacionAmbiental { get; set; }
        
        [Column("FECHA_HORA_MEDICION")]
        public DateTime? FechaHoraMedicion { get; set; }
        
        [Column("CO2_PPM")]
        public decimal? Co2Ppm { get; set; }
        
        [Column("CO_PPM")]
        public decimal? CoPpm { get; set; }
        
        [Column("NOX_PPM")]
        public decimal? NoxPpm { get; set; }
        
        [Column("SO2_PPM")]
        public decimal? So2Ppm { get; set; }
        
        [Column("PARTICULAS_PM10")]
        public decimal? ParticulasPm10 { get; set; }
        
        [Column("PARTICULAS_PM25")]
        public decimal? ParticulasPm25 { get; set; }
        
        [Column("COMPUESTOS_ORGANICOS_VOLATILES")]
        public decimal? CompuestosOrganicosVolatiles { get; set; }
        
        [Column("TEMPERATURA_AMBIENTE")]
        public decimal? TemperaturaAmbiente { get; set; }
        
        [Column("HUMEDAD_RELATIVA")]
        public decimal? HumedadRelativa { get; set; }
        
        [Column("PRESION_ATMOSFERICA")]
        public decimal? PresionAtmosferica { get; set; }
        
        [Column("VELOCIDAD_VIENTO")]
        public decimal? VelocidadViento { get; set; }
        
        [Column("DIRECCION_VIENTO")]
        public string? DireccionViento { get; set; }
        
        [Column("INDICE_CALIDAD_AIRE")]
        public decimal? IndiceCalidadAire { get; set; }
        
        [Column("ALERTA_GENERADA")]
        public decimal? AlertaGenerada { get; set; }
    }
}

