using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models.RRHH
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [Column("ID_DEPARTAMENTO")]
        public int IdDepartamento { get; set; }

        [Column("NOMBRE_DEPARTAMENTO")]
        public string NombreDepartamento { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("RESPONSABLE")]
        public string? Responsable { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("PUESTOS_TRABAJO")]
    public class PuestoTrabajo
    {
        [Key]
        [Column("ID_PUESTO")]
        public int IdPuesto { get; set; }

        [Column("NOMBRE_PUESTO")]
        public string NombrePuesto { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("SALARIO_BASE")]
        public decimal? SalarioBase { get; set; }

        [Column("ID_DEPARTAMENTO")]
        public int? IdDepartamento { get; set; }

        [NotMapped]
        public string? NombreDepartamento { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Key]
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }

        [Column("NOMBRES")]
        public string Nombres { get; set; } = string.Empty;

        [Column("APELLIDOS")]
        public string Apellidos { get; set; } = string.Empty;

        [Column("DPI")]
        public string? Dpi { get; set; }

        [Column("FECHA_NACIMIENTO")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Column("FECHA_INGRESO")]
        public DateTime FechaIngreso { get; set; }

        [Column("ID_PUESTO")]
        public int? IdPuesto { get; set; }

        [NotMapped]
        public string? NombrePuesto { get; set; }

        [Column("ID_DEPARTAMENTO")]
        public int? IdDepartamento { get; set; }

        [NotMapped]
        public string? NombreDepartamento { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "Activo";

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("CAPACITACIONES")]
    public class Capacitacion
    {
        [Key]
        [Column("ID_CAPACITACION")]
        public int IdCapacitacion { get; set; }

        [Column("NOMBRE_CAPACITACION")]
        public string NombreCapacitacion { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("TIPO")]
        public string? Tipo { get; set; }

        [Column("DURACION_HORAS")]
        public int? DuracionHoras { get; set; }

        [Column("INSTRUCTOR")]
        public string? Instructor { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
