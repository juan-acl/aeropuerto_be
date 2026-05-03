using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Key]
        [Column("ID_EMPLEADO")]
        public int id_empleado { get; set; }

        [Column("CODIGO_EMPLEADO")]
        public string? codigo_empleado { get; set; }

        [Column("NOMBRES")]
        public string? nombres { get; set; }

        [Column("APELLIDOS")]
        public string? apellidos { get; set; }

        [Column("TIPO_DOCUMENTO")]
        public string? tipo_documento { get; set; }

        [Column("NUMERO_DOCUMENTO")]
        public string? numero_documento { get; set; }

        [Column("FECHA_NACIMIENTO")]
        public DateTime? fecha_nacimiento { get; set; }

        [Column("NACIONALIDAD")]
        public string? nacionalidad { get; set; }

        [Column("GENERO")]
        public string? genero { get; set; } // M, F, O

        [Column("DIRECCION")]
        public string? direccion { get; set; }

        [Column("TELEFONO")]
        public string? telefono { get; set; }

        [Column("EMAIL")]
        public string? email { get; set; }

        [Column("FECHA_CONTRATACION")]
        public DateTime? fecha_contratacion { get; set; }

        [Column("DEPARTAMENTO")]
        public string? departamento { get; set; }

        [Column("CARGO")]
        public string? cargo { get; set; }

        [Column("SALARIO_BASE")]
        public decimal? salario_base { get; set; }

        [Column("TIPO_CONTRATO")]
        public string? tipo_contrato { get; set; } // PERMANENTE, TEMPORAL, PRACTICAS, CONSULTOR

        [Column("ACTIVO")]
        public int? activo { get; set; }

        [Column("FOTO_EMPLEADO")]
        public byte[]? foto_empleado { get; set; }
    }
}