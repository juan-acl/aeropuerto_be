using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("REACCIONES_PROMOCIONES")]
    public class ReaccionesPromociones
    {
        
        [Key]
        [Column("ID_REACCION")]
        public Int32 IdReaccion { get; set; }
        
        [Column("ID_OFERTA_PERSONALIZADA")]
        public decimal IdOfertaPersonalizada { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("FECHA_REACCION")]
        public DateTime? FechaReaccion { get; set; }
        
        [Column("TIPO_REACCION")]
        public string? TipoReaccion { get; set; }
        
        [Column("CANAL")]
        public string? Canal { get; set; }
        
        [Column("CONVERTIDO_EN_RESERVA")]
        public decimal? ConvertidoEnReserva { get; set; }
        
        [Column("ID_RESERVA")]
        public decimal? IdReserva { get; set; }
        
        [Column("VALOR_CONVERSION")]
        public decimal? ValorConversion { get; set; }
        

      
    }
}
