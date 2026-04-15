using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("OFERTAS_PERSONALIZADAS")]
    public class OfertasPersonalizadas
    {
        
        [Key]
        [Column("ID_OFERTA_PERSONALIZADA")]
        public int IdOfertaPersonalizada { get; set; }
        
        [Column("ID_SEGMENTO_CLIENTE")]
        public decimal? IdSegmentoCliente { get; set; }
        
        [Column("ID_PROMOCION")]
        public decimal? IdPromocion { get; set; }
        
        [Column("TITULO_OFERTA")]
        public string TituloOferta { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("CONDICIONES")]
        public string? Condiciones { get; set; }
        
        [Column("DESCUENTO_PORCENTAJE")]
        public decimal? DescuentoPorcentaje { get; set; }
        
        [Column("DESCUENTO_FIJO")]
        public decimal? DescuentoFijo { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        
        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }
        
        [Column("PRIORIDAD")]
        public decimal? Prioridad { get; set; }
        
        [Column("VISUALIZACIONES")]
        public decimal? Visualizaciones { get; set; }
        
        [Column("CONVERSIONES")]
        public decimal? Conversiones { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("CREADA_POR")]
        public decimal? CreadaPor { get; set; }
        

    }
}
