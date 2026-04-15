using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("RESERVAS_TRANSPORTE_TERRESTRE")]
    public class ReservasTransporteTerrestre
    {
        
        [Key]
        [Column("ID_RESERVA_TRANSPORTE")]
        public int IdReservaTransporte { get; set; }
        
        [Column("CODIGO_RESERVA_TRANSPORTE")]
        public string CodigoReservaTransporte { get; set; } = null!;
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("ID_RUTA_TRANSPORTE")]
        public decimal IdRutaTransporte { get; set; }
        
        [Column("TIPO_SERVICIO")]
        public string? TipoServicio { get; set; }
        
        [Column("FECHA_RESERVA")]
        public DateTime? FechaReserva { get; set; }
        
        [Column("FECHA_SERVICIO")]
        public DateTime FechaServicio { get; set; }
        
        [Column("HORA_RECOGIDA")]
        public DateTime HoraRecogida { get; set; }
        
        [Column("LUGAR_RECOGIDA")]
        public string LugarRecogida { get; set; } = null!;
        
        [Column("LUGAR_DESTINO")]
        public string LugarDestino { get; set; } = null!;
        
        [Column("NUMERO_PASAJEROS")]
        public decimal? NumeroPasajeros { get; set; }
        
        [Column("CANTIDAD_MALETAS")]
        public decimal? CantidadMaletas { get; set; }
        
        [Column("ID_VUELO_ASOCIADO")]
        public decimal? IdVueloAsociado { get; set; }
        
        [Column("INSTRUCCIONES_ESPECIALES")]
        public string? InstruccionesEspeciales { get; set; }
        
        [Column("ESTADO_RESERVA")]
        public string? EstadoReserva { get; set; }
        
        [Column("PRECIO_TOTAL")]
        public decimal? PrecioTotal { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("PAGADO")]
        public decimal? Pagado { get; set; }
        

    }
}
