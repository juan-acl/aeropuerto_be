using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("POLITICAS_SEGURIDAD")]
    public class PoliticasSeguridad
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_POLITICA")]
        public int IdPolitica { get; set; }
        
        [Column("NOMBRE_POLITICA")]
        public string NombrePolitica { get; set; } = null!;
        
        [Column("VERSION")]
        public string? Version { get; set; }
        
        [Column("FECHA_APROBACION")]
        public DateTime? FechaAprobacion { get; set; }
        
        [Column("FECHA_VIGENCIA")]
        public DateTime? FechaVigencia { get; set; }
        
        [Column("FECHA_REVISION")]
        public DateTime? FechaRevision { get; set; }
        
        [Column("CONTENIDO")]
        public string? Contenido { get; set; }
        
        [Column("APROBADO_POR")]
        public decimal? AprobadoPor { get; set; }
        
        [Column("RESPONSABLE_EJECUCION")]
        public decimal? ResponsableEjecucion { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }

    }
}
