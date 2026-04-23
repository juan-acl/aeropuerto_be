using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PROVEEDOR")]
    public class Proveedor
    {
        [Key]
        [Column("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; } = null!;
        [Column("NIT")]
        public string Nit { get; set; } = null!;
        [Column("DIRECCION")]
        public string Direccion { get; set; } = null!;
        [Column("TELEFONO")]
        public string Telefono { get; set; } = null!;
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        [Column("CONTACTO_NOMBRE")]
        public string ContactoNombre { get; set; } = null!;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}