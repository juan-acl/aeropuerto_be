using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Models
{
    [Table("USUARIOS_ROLES")]
    [PrimaryKey(nameof(IdUsuarioSistema), nameof(IdRolSistema))]
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
        
    }
}
