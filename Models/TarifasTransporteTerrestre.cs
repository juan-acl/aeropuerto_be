using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TARIFAS_TRANSPORTE_TERRESTRE")]
    public class TarifasTransporteTerrestre
    {
        
        [Key]
        [Column("ID_TARIFA_TRANSPORTE")]
        public int IdTarifaTransporte { get; set; }
        
        [Column("ID_RUTA_TRANSPORTE")]
        public decimal IdRutaTransporte { get; set; }
        
        [Column("TIPO_TARIFA")]
        public string? TipoTarifa { get; set; }
        
        [Column("PRECIO_POR_PERSONA")]
        public decimal? PrecioPorPersona { get; set; }
        
        [Column("PRECIO_VEHICULO_PRIVADO")]
        public decimal? PrecioVehiculoPrivado { get; set; }
        
        [Column("PRECIO_MALETA_EXTRA")]
        public decimal? PrecioMaletaExtra { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("HORA_INICIO_APLICACION")]
        public string? HoraInicioAplicacion { get; set; }
        
        [Column("HORA_FIN_APLICACION")]
        public string? HoraFinAplicacion { get; set; }
        
        [Column("DIAS_APLICACION")]
        public string? DiasAplicacion { get; set; }
        
        [Column("FECHA_INICIO_VIGENCIA")]
        public DateTime FechaInicioVigencia { get; set; }
        
        [Column("FECHA_FIN_VIGENCIA")]
        public DateTime? FechaFinVigencia { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
