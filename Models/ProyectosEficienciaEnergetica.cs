using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROYECTOS_EFICIENCIA_ENERGETICA")]
    public class ProyectosEficienciaEnergetica
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PROYECTO_EFICIENCIA")]
        public int IdProyectoEficiencia { get; set; }
        
        [Column("NOMBRE_PROYECTO")]
        public string NombreProyecto { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("TIPO_PROYECTO")]
        public string? TipoProyecto { get; set; }
        
        [Column("INVERSION_TOTAL")]
        public decimal? InversionTotal { get; set; }
        
        [Column("AHORRO_ENERGETICO_ANUAL_KWH")]
        public decimal? AhorroEnergeticoAnualKwh { get; set; }
        
        [Column("REDUCCION_CO2_ANUAL_KG")]
        public decimal? ReduccionCo2AnualKg { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }
        
        [Column("FECHA_FINALIZACION")]
        public DateTime? FechaFinalizacion { get; set; }
        
        [Column("PERIODO_RETORNO_ANIOS")]
        public decimal? PeriodoRetornoAnios { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("RESPONSABLE_PROYECTO")]
        public string? ResponsableProyecto { get; set; }
        
        [Column("RESULTADOS_OBTENIDOS")]
        public string? ResultadosObtenidos { get; set; }
    }
}
