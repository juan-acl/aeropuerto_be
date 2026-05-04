using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROVEEDORES_COMBUSTIBLE")]
    public class ProveedoresCombustible
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PROVEEDOR_COMBUSTIBLE")]
        public decimal IdProveedorCombustible { get; set; }
        
        [Column("ID_PROVEEDOR")]
        public decimal? IdProveedor { get; set; }
        
        [Column("TIPO_COMBUSTIBLE_SUMINISTRADO")]
        public string? TipoCombustibleSuministrado { get; set; }
        
        [Column("PRECIO_COMPRA_GALON")]
        public decimal? PrecioCompraGalon { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("CONTRATO_VIGENTE")]
        public decimal? ContratoVigente { get; set; }
        
        [Column("FECHA_INICIO_CONTRATO")]
        public DateTime? FechaInicioContrato { get; set; }
        
        [Column("FECHA_FIN_CONTRATO")]
        public DateTime? FechaFinContrato { get; set; }
        
        [Column("VOLUMEN_MINIMO_CONTRATO")]
        public decimal? VolumenMinimoContrato { get; set; }
        
        [Column("CONDICIONES_ESPECIALES")]
        public string? CondicionesEspeciales { get; set; }
    }
}

