using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PUESTOS_TRABAJO")]
    public class PuestoTrabajo
    {
        [Key]
        [Column("ID_PUESTO")]
        public int id_puesto { get; set; }

        [Column("NOMBRE_PUESTO")]
        public string? nombre_puesto { get; set; }

        [Column("ID_DEPARTAMENTO")]
        public int? id_departamento { get; set; }

        [Column("NIVEL_JERARQUICO")]
        public int? nivel_jerarquico { get; set; }

        [Column("SALARIO_MINIMO")]
        public decimal? salario_minimo { get; set; }

        [Column("SALARIO_MAXIMO")]
        public decimal? salario_maximo { get; set; }

        [Column("DESCRIPCION_FUNCIONES")]
        public string? descripcion_funciones { get; set; }

        [Column("REQUISITOS")]
        public string? requisitos { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}