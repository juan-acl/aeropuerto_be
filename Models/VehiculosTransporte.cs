using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("VEHICULOS_TRANSPORTE")]
    public class VehiculosTransporte
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_VEHICULO_TRANSPORTE")]
        public int IdVehiculoTransporte { get; set; }
        
        [Column("PLACA")]
        public string Placa { get; set; } = null!;
        
        [Column("TIPO_VEHICULO")]
        public string? TipoVehiculo { get; set; }
        
        [Column("MARCA")]
        public string? Marca { get; set; }
        
        [Column("MODELO")]
        public string? Modelo { get; set; }
        
        [Column("ANIO")]
        public decimal? Anio { get; set; }
        
        [Column("CAPACIDAD_PASAJEROS")]
        public decimal? CapacidadPasajeros { get; set; }
        
        [Column("CAPACIDAD_MALETAS")]
        public decimal? CapacidadMaletas { get; set; }
        
        [Column("TIENE_AIRE_ACONDICIONADO")]
        public decimal? TieneAireAcondicionado { get; set; }
        
        [Column("TIENE_WIFI")]
        public decimal? TieneWifi { get; set; }
        
        [Column("TIENE_ACCESIBILIDAD")]
        public decimal? TieneAccesibilidad { get; set; }
        
        [Column("PROPIETARIO")]
        public string? Propietario { get; set; }
        
        [Column("EMPRESA_OPERADORA")]
        public string? EmpresaOperadora { get; set; }
        
        [Column("FECHA_ULTIMO_MANTENIMIENTO")]
        public DateTime? FechaUltimoMantenimiento { get; set; }
        
        [Column("FECHA_PROXIMO_MANTENIMIENTO")]
        public DateTime? FechaProximoMantenimiento { get; set; }
        
        [Column("DISPONIBLE")]
        public decimal? Disponible { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
