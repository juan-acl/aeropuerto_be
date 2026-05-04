using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ROLES_SISTEMA")]
    public class RolesSistema
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ROL_SISTEMA")]
        public int IdRolSistema { get; set; }
        
        [Column("NOMBRE_ROL")]
        public string NombreRol { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("NIVEL_JERARQUICO")]
        public decimal? NivelJerarquico { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
