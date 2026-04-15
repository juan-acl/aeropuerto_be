using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INDICADORES_DESEMPENO_AMBIENTAL")]
    public class IndicadoresDesempenoAmbiental
    {
        
        [Key]
        [Column("ID_INDICADOR_AMBIENTAL")]
        public int IdIndicadorAmbiental { get; set; }
        
        [Column("ANIO")]
        public decimal Anio { get; set; }
        
        [Column("MES")]
        public decimal? Mes { get; set; }
        
        [Column("INDICADOR")]
        public string? Indicador { get; set; }
        
        [Column("VALOR_MEDIDO")]
        public decimal? ValorMedido { get; set; }
        
        [Column("UNIDAD_MEDIDA")]
        public string? UnidadMedida { get; set; }
        
        [Column("VALOR_OBJETIVO")]
        public decimal? ValorObjetivo { get; set; }
        
        [Column("CUMPLIMIENTO_PORCENTAJE")]
        public decimal? CumplimientoPorcentaje { get; set; }
        
        [Column("TENDENCIA")]
        public string? Tendencia { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
