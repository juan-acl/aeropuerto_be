using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [Column("ID_DEPARTAMENTO")]
        public int id_departamento { get; set; }

        [Column("NOMBRE_DEPARTAMENTO")]
        public string? nombre_departamento { get; set; }

        [Column("DESCRIPCION")]
        public string? descripcion { get; set; }

        [Column("UBICACION")]
        public string? ubicacion { get; set; }

        [Column("PRESUPUESTO_ANUAL")]
        public decimal? presupuesto_anual { get; set; }

        [Column("GERENTE_ID")]
        public int? gerente_id { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}