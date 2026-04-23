using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INSPECTOR_ADUANA")]
    public class InspectorAduana
    {
        [Key]
        [Column("ID_INSPECTOR")]
        public int IdInspector { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; } = null!;
        [Column("CREDENCIAL")]
        public string Credencial { get; set; } = null!;
        [Column("TURNO")]
        public string Turno { get; set; } = null!;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}