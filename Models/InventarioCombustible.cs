using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INVENTARIO_COMBUSTIBLE")]
    public class InventarioCombustible
    {
        
        [Key]
        [Column("ID_INVENTARIO")]
        public int IdInventario { get; set; }
        
        [Column("ID_TANQUE")]
        public decimal IdTanque { get; set; }
        
        [Column("FECHA_INVENTARIO")]
        public DateTime FechaInventario { get; set; }
        
        [Column("NIVEL_MEDIDO_LITROS")]
        public decimal? NivelMedidoLitros { get; set; }
        
        [Column("NIVEL_TEORICO_LITROS")]
        public decimal? NivelTeoricoLitros { get; set; }
        
        [Column("DIFERENCIA_LITROS")]
        public decimal? DiferenciaLitros { get; set; }
        
        [Column("PORCENTAJE_DIFERENCIA")]
        public decimal? PorcentajeDiferencia { get; set; }
        
        [Column("TEMPERATURA_PROMEDIO")]
        public decimal? TemperaturaPromedio { get; set; }
        
        [Column("TIPO_INVENTARIO")]
        public string? TipoInventario { get; set; }
        
        [Column("REALIZADO_POR")]
        public decimal? RealizadoPor { get; set; }
        
        [Column("VERIFICADO_POR")]
        public decimal? VerificadoPor { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        

    }
}
