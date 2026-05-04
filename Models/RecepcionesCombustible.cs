using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RECEPCIONES_COMBUSTIBLE")]
    public class RecepcionesCombustible
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RECEPCION")]
        public int IdRecepcion { get; set; }
        
        [Column("ID_PROVEEDOR_COMBUSTIBLE")]
        public decimal? IdProveedorCombustible { get; set; }
        
        [Column("ID_TANQUE")]
        public decimal? IdTanque { get; set; }
        
        [Column("NUMERO_GUIA")]
        public string? NumeroGuia { get; set; }
        
        [Column("FECHA_RECEPCION")]
        public DateTime? FechaRecepcion { get; set; }
        
        [Column("CANTIDAD_RECIBIDA_LITROS")]
        public decimal? CantidadRecibidaLitros { get; set; }
        
        [Column("CANTIDAD_FACTURADA_LITROS")]
        public decimal? CantidadFacturadaLitros { get; set; }
        
        [Column("TEMPERATURA_RECEPCION")]
        public decimal? TemperaturaRecepcion { get; set; }
        
        [Column("DENSIDAD_RECEPCION")]
        public decimal? DensidadRecepcion { get; set; }
        
        [Column("PLACA_CAMION")]
        public string? PlacaCamion { get; set; }
        
        [Column("TRANSPORTISTA")]
        public string? Transportista { get; set; }
        
        [Column("CONDUCTOR")]
        public string? Conductor { get; set; }
        
        [Column("LICENCIA_CONDUCTOR")]
        public string? LicenciaConductor { get; set; }
        
        [Column("INSPECTOR_RECIBE")]
        public decimal? InspectorRecibe { get; set; }
        
        [Column("CERTIFICADO_CALIDAD")]
        public byte[]? CertificadoCalidad { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        

    }
}
