using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CAPACIDAD_TERMINAL_TIEMPO_REAL")]
    public class CapacidadTerminalTiempoReal
    {
        
        [Key]
        [Column("ID_MEDICION_TERMINAL")]
        public decimal IdMedicionTerminal { get; set; }
        
        [Column("TERMINAL")]
        public string Terminal { get; set; } = null!;
        
        [Column("FECHA_HORA_MEDICION")]
        public DateTime? FechaHoraMedicion { get; set; }
        
        [Column("PASAJEROS_ACTUALES")]
        public decimal? PasajerosActuales { get; set; }
        
        [Column("PASAJEROS_ESTIMADOS_SALIDA")]
        public decimal? PasajerosEstimadosSalida { get; set; }
        
        [Column("PASAJEROS_ESTIMADOS_LLEGADA")]
        public decimal? PasajerosEstimadosLlegada { get; set; }
        
        [Column("PASAJEROS_EN_TRANSITO")]
        public decimal? PasajerosEnTransito { get; set; }
        
        [Column("CAPACIDAD_MAXIMA")]
        public decimal? CapacidadMaxima { get; set; }
        
        [Column("PORCENTAJE_OCUPACION")]
        public decimal? PorcentajeOcupacion { get; set; }
        
        [Column("NIVEL_CONGESTION")]
        public string? NivelCongestion { get; set; }
        
        [Column("TIEMPO_ESPERA_SEGURIDAD_MINUTOS")]
        public decimal? TiempoEsperaSeguridadMinutos { get; set; }
        
        [Column("MEDICION_AUTOMATICA")]
        public decimal? MedicionAutomatica { get; set; }
        
        [Column("REGISTRADO_POR")]
        public decimal? RegistradoPor { get; set; }
    }
}
