using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PUESTO_TRABAJO")]
    public class PuestoTrabajo
    {
        [Key]
        [Column("ID_PUESTO")]
        public int IdPuesto { get; set; }
        [Column("NOMBRE_PUESTO")]
        public string NombrePuesto { get; set; } = null!;
        [Column("ID_DEPARTAMENTO")]
        public int IdDepartamento { get; set; }
        [Column("NIVEL_JERARQUICO")]
        public int NivelJerarquico { get; set; }
        [Column("SALARIO_MINIMO")]
        public decimal SalarioMinimo { get; set; }
        [Column("SALARIO_MAXIMO")]
        public decimal SalarioMaximo { get; set; }
        [Column("DESCRIPCION_FUNCIONES")]
        public string DescripcionFunciones { get; set; } = null!;
        [Column("REQUISITOS")]
        public string Requisitos { get; set; } = null!;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}