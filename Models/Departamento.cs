using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Aeropuerto.Backend.Models
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [Column("ID_DEPARTAMENTO")]
        [JsonPropertyName("ID_DEPARTAMENTO")]
        public int IdDepartamento { get; set; }

        [Column("NOMBRE_DEPARTAMENTO")]
        [JsonPropertyName("NOMBRE_DEPARTAMENTO")]
        public string Nombre { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        [JsonPropertyName("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("UBICACION")]
        [JsonPropertyName("UBICACION")]
        public string? Ubicacion { get; set; }

        [Column("PRESUPUESTO_ANUAL")]
        [JsonPropertyName("PRESUPUESTO_ANUAL")]
        public decimal? PresupuestoAnual { get; set; }

        [Column("GERENTE_ID")]
        [JsonPropertyName("GERENTE_ID")]
        public int? GerenteId { get; set; }

        [Column("ACTIVO")]
        [JsonPropertyName("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}