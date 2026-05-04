using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROVEEDOR_REPUESTO")]
    public class ProveedorRepuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PROVEEDOR_REP")]
        public int IdProveedorRep { get; set; }
        [Column("NOMBRE_PROVEEDOR")]
        public string NombreProveedor { get; set; } = null!;
        [Column("TELEFONO")]
        public string Telefono { get; set; } = null!;
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; } = null!; // MOTORES, FUSELAJE, ELECTRÓNICA
    }
}
