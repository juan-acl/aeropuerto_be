using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PEDIDOS_COMBUSTIBLE")]
    public class PedidosCombustible
    {
        
        [Key]
        [Column("ID_PEDIDO_COMBUSTIBLE")]
        public decimal IdPedidoCombustible { get; set; }
        
        [Column("NUMERO_PEDIDO")]
        public string NumeroPedido { get; set; } = null!;
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("CANTIDAD_SOLICITADA_LITROS")]
        public decimal? CantidadSolicitadaLitros { get; set; }
        
        [Column("TIPO_COMBUSTIBLE")]
        public string? TipoCombustible { get; set; }
        
        [Column("FECHA_PEDIDO")]
        public DateTime? FechaPedido { get; set; }
        
        [Column("FECHA_REQUERIDA")]
        public DateTime? FechaRequerida { get; set; }
        
        [Column("ESTADO_PEDIDO")]
        public string? EstadoPedido { get; set; }
        
        [Column("PRIORIDAD")]
        public string? Prioridad { get; set; }
        
        [Column("SOLICITADO_POR")]
        public decimal? SolicitadoPor { get; set; }
        
        [Column("APROBADO_POR")]
        public decimal? AprobadoPor { get; set; }
    
    }
}
