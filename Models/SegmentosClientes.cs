using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SEGMENTOS_CLIENTES")]
    public class SegmentosClientes
    {
        
        [Key]
        [Column("ID_SEGMENTO_CLIENTE")]
        public int IdSegmentoCliente { get; set; }
        
        [Column("NOMBRE_SEGMENTO")]
        public string NombreSegmento { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("CRITERIOS_JSON")]
        public string? CriteriosJson { get; set; }
        
        [Column("FRECUENCIA_VIAJES")]
        public string? FrecuenciaViajes { get; set; }
        
        [Column("CLASE_PREFERIDA")]
        public string? ClasePreferida { get; set; }
        
        [Column("DESTINOS_FRECUENTES")]
        public string? DestinosFrecuentes { get; set; }
        
        [Column("EDAD_PROMEDIO")]
        public decimal? EdadPromedio { get; set; }
        
        [Column("NIVEL_INGRESOS")]
        public string? NivelIngresos { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
