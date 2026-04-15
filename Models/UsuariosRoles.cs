using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("USUARIOS_ROLES")]
    public class UsuariosRoles
    {
        
        [Column("ID_USUARIO_SISTEMA")]
        public int IdUsuarioSistema { get; set; }
        
        [Column("ID_ROL_SISTEMA")]
        public decimal? IdRolSistema { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("ASIGNADO_POR")]
        public decimal? AsignadoPor { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
        [Key]
        [Column("PRIMARY")]
        public decimal Primary { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
  
    }
}
