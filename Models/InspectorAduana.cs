using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("INSPECTOR_ADUANA")]
    public class InspectorAduana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
