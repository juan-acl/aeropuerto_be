using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("CODIGO_EMPLEADO")]
        public string CodigoEmpleado { get; set; } = null!;
        [Column("NOMBRES")]
        public string Nombres { get; set; } = null!;
        [Column("APELLIDOS")]
        public string Apellidos { get; set; } = null!;
        [Column("TIPO_DOCUMENTO")]
        public string TipoDocumento { get; set; } = null!;
        [Column("NUMERO_DOCUMENTO")]
        public string NumeroDocumento { get; set; } = null!;
        [Column("FECHA_NACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }
        [Column("NACIONALIDAD")]
        public string Nacionalidad { get; set; } = null!;
        [Column("GENERO")]
        public string Genero { get; set; } = null!; // 'M', 'F', 'O'
        [Column("DIRECCION")]
        public string Direccion { get; set; } = null!;
        [Column("TELEFONO")]
        public string Telefono { get; set; } = null!;
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        [Column("FECHA_CONTRATACION")]
        public DateTime FechaContratacion { get; set; }
        [Column("DEPARTAMENTO")]
        public string Departamento { get; set; } = null!;
        [Column("CARGO")]
        public string Cargo { get; set; } = null!;
        [Column("SALARIO_BASE")]
        public decimal SalarioBase { get; set; }
        [Column("TIPO_CONTRATO")]
        public string TipoContrato { get; set; } = null!;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
        [Column("FOTO_EMPLEADO")]
        public byte[]? FotoEmpleado { get; set; }
    }
}
