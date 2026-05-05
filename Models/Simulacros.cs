using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("SIMULACROS")]
    public class Simulacros
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SIMULACRO")]
        public int IdSimulacro { get; set; }
        
        [Column("FECHA_SIMULACRO")]
        public DateTime FechaSimulacro { get; set; }
        
        [Column("TIPO_SIMULACRO")]
        public string? TipoSimulacro { get; set; }
        
        [Column("ID_PLAN_EMERGENCIA")]
        public decimal? IdPlanEmergencia { get; set; }
        
        [Column("ALCANCE")]
        public string? Alcance { get; set; }
        
        [Column("PARTICIPANTES")]
        public decimal? Participantes { get; set; }
        
        [Column("DURACION_HORAS")]
        public decimal? DuracionHoras { get; set; }
        
        [Column("OBJETIVOS")]
        public string? Objetivos { get; set; }
        
        [Column("RESULTADOS")]
        public string? Resultados { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("EVALUACION")]
        public string? Evaluacion { get; set; }
        
        [Column("COORDINADOR")]
        public string? Coordinador { get; set; }
        
        [Column("FECHA_PROXIMO_SIMULACRO")]
        public DateTime? FechaProximoSimulacro { get; set; }
    }
}

