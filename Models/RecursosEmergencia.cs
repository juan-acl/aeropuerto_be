using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RECURSOS_EMERGENCIA")]
    public class RecursosEmergencia
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RECURSO_EMERGENCIA")]
        public int IdRecursoEmergencia { get; set; }
        
        [Column("TIPO_RECURSO")]
        public string? TipoRecurso { get; set; }
        
        [Column("NOMBRE_RECURSO")]
        public string NombreRecurso { get; set; } = null!;
        
        [Column("CANTIDAD_DISPONIBLE")]
        public decimal? CantidadDisponible { get; set; }
        
        [Column("UBICACION_ALMACEN")]
        public string? UbicacionAlmacen { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("PROVEEDOR")]
        public string? Proveedor { get; set; }
        
        [Column("RESPONSABLE_MANTENIMIENTO")]
        public string? ResponsableMantenimiento { get; set; }
        
        [Column("FECHA_ULTIMA_REVISION")]
        public DateTime? FechaUltimaRevision { get; set; }
        
        [Column("FECHA_PROXIMA_REVISION")]
        public DateTime? FechaProximaRevision { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
