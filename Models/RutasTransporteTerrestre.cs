using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("RUTAS_TRANSPORTE_TERRESTRE")]
    public class RutasTransporteTerrestre
    {
        
        [Key]
        [Column("ID_RUTA_TRANSPORTE")]
        public int IdRutaTransporte { get; set; }
        
        [Column("CODIGO_RUTA")]
        public string CodigoRuta { get; set; } = null!;
        
        [Column("NOMBRE_RUTA")]
        public string NombreRuta { get; set; } = null!;
        
        [Column("ORIGEN")]
        public string Origen { get; set; } = null!;
        
        [Column("DESTINO")]
        public string Destino { get; set; } = null!;
        
        [Column("DISTANCIA_KM")]
        public decimal? DistanciaKm { get; set; }
        
        [Column("DURACION_ESTIMADA_MINUTOS")]
        public decimal? DuracionEstimadaMinutos { get; set; }
        
        [Column("TIPO_RUTA")]
        public string? TipoRuta { get; set; }
        
        [Column("FRECUENCIA_SERVICIO")]
        public string? FrecuenciaServicio { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
    }
}
