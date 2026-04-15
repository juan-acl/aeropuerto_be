using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CARGAS_COMBUSTIBLE")]
    public class CargasCombustible
    {
        
        [Key]
        [Column("ID_CARGA_COMBUSTIBLE")]
        public int IdCargaCombustible { get; set; }
        
        [Column("ID_PEDIDO_COMBUSTIBLE")]
        public decimal IdPedidoCombustible { get; set; }
        
        [Column("ID_SURTIDOR")]
        public decimal? IdSurtidor { get; set; }
        
        [Column("CANTIDAD_REAL_LITROS")]
        public decimal? CantidadRealLitros { get; set; }
        
        [Column("TEMPERATURA_COMBUSTIBLE")]
        public decimal? TemperaturaCombustible { get; set; }
        
        [Column("DENSIDAD_COMBUSTIBLE")]
        public decimal? DensidadCombustible { get; set; }
        
        [Column("FECHA_INICIO_CARGA")]
        public DateTime? FechaInicioCarga { get; set; }
        
        [Column("FECHA_FIN_CARGA")]
        public DateTime? FechaFinCarga { get; set; }
        
        [Column("DURACION_MINUTOS")]
        public decimal? DuracionMinutos { get; set; }
        
        [Column("OPERADOR_CARGA")]
        public decimal? OperadorCarga { get; set; }
        
        [Column("VERIFICADOR")]
        public decimal? Verificador { get; set; }
        
        [Column("LECTURA_INICIAL_CONTADOR")]
        public decimal? LecturaInicialContador { get; set; }
        
        [Column("LECTURA_FINAL_CONTADOR")]
        public decimal? LecturaFinalContador { get; set; }
        
        [Column("INCIDENCIA_TECNICA")]
        public decimal? IncidenciaTecnica { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        

    }
}
