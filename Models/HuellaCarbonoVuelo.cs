using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("HUELLA_CARBONO_VUELO")]
    public class HuellaCarbonoVuelo
    {
        
        [Key]
        [Column("ID_HUELLA_CARBONO")]
        public int IdHuellaCarbono { get; set; }
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("COMBUSTIBLE_CONSUMIDO_LITROS")]
        public decimal? CombustibleConsumidoLitros { get; set; }
        
        [Column("FACTOR_EMISION_CO2")]
        public decimal? FactorEmisionCo2 { get; set; }
        
        [Column("CO2_EMITIDO_KG")]
        public decimal? Co2EmitidoKg { get; set; }
        
        [Column("CO2_POR_PASAJERO_KG")]
        public decimal? Co2PorPasajeroKg { get; set; }
        
        [Column("CO2_POR_KM")]
        public decimal? Co2PorKm { get; set; }
        
        [Column("DISTANCIA_VUELO_KM")]
        public decimal? DistanciaVueloKm { get; set; }
        
        [Column("CATEGORIA_VUELO")]
        public string? CategoriaVuelo { get; set; }
        
        [Column("EFICIENCIA_COMBUSTIBLE_KG_KM")]
        public decimal? EficienciaCombustibleKgKm { get; set; }
        
        [Column("FECHA_CALCULO")]
        public DateTime? FechaCalculo { get; set; }
        
        [Column("METODO_CALCULO")]
        public string? MetodoCalculo { get; set; }
        
        [Column("CERTIFICADO_COMPENSACION")]
        public decimal? CertificadoCompensacion { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
