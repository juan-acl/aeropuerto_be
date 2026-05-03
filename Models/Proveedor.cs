using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PROVEEDORES")]
    public class Proveedor
    {
        [Key]
        [Column("ID_PROVEEDOR")]
        public int id_proveedor { get; set; }

        [Column("NOMBRE_PROVEEDOR")]
        public string? nombre_proveedor { get; set; }

        [Column("TIPO_PROVEEDOR")]
        public string? tipo_proveedor { get; set; } // COMBUSTIBLE, CATERING, MANTENIMIENTO, LIMPIEZA, SEGURIDAD, TECNOLOGIA

        [Column("NIT")]
        public string? nit { get; set; }

        [Column("DIRECCION")]
        public string? direccion { get; set; }

        [Column("TELEFONO")]
        public string? telefono { get; set; }

        [Column("EMAIL")]
        public string? email { get; set; }

        [Column("CONTACTO_NOMBRE")]
        public string? contacto_nombre { get; set; }

        [Column("CONTACTO_TELEFONO")]
        public string? contacto_telefono { get; set; }

        [Column("CONDICIONES_PAGO")]
        public string? condiciones_pago { get; set; }

        [Column("CALIFICACION")]
        public int? calificacion { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}