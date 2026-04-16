using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PREFERENCIAS_IDIOMAS")]
    public class PreferenciaIdiomaModel
    {
        [Key]
        [Column("ID_PREFERENCIA_IDIOMA")]
        public int IdPreferenciaIdioma { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("IDIOMA")]
        public string Idioma { get; set; } = null!;

        [Column("NIVEL")]
        public string Nivel { get; set; } = null!; // NATIVO, AVANZADO, BASICO

        [Column("PREFERIDO")]
        public int Preferido { get; set; } // 0 o 1
    }
}