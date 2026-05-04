using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MODULOS_SISTEMA")]
    public class ModulosSistema
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MODULO_SISTEMA")]
        public int IdModuloSistema { get; set; }
        
        [Column("NOMBRE_MODULO")]
        public string NombreModulo { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("RUTA_ACCESO")]
        public string? RutaAcceso { get; set; }
        
        [Column("ICONO")]
        public string? Icono { get; set; }
        
        [Column("ORDEN")]
        public decimal? Orden { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
