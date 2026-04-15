using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ROLES_PERMISOS_MODULOS")]
    public class RolesPermisosModulos
    {
        
        [Column("ID_ROL_SISTEMA")]
        public int IdRolSistema { get; set; }
        
        [Column("ID_MODULO_SISTEMA")]
        public decimal? IdModuloSistema { get; set; }
        
        [Column("PERMISO_LECTURA")]
        public decimal? PermisoLectura { get; set; }
        
        [Column("PERMISO_ESCRITURA")]
        public decimal? PermisoEscritura { get; set; }
        
        [Column("PERMISO_ELIMINACION")]
        public decimal? PermisoEliminacion { get; set; }
        
        [Column("PERMISO_EJECUCION")]
        public decimal? PermisoEjecucion { get; set; }
        
        [Key]
        [Column("PRIMARY")]
        public decimal Primary { get; set; }

    }
}
