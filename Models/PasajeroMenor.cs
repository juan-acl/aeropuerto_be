using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJERO_MENOR")]
    public class PasajeroMenor
    {
        [Key]
        [Column("ID_PASAJERO_MENOR")]
        public int IdPasajeroMenor { get; set; }
        [Column("NOMBRES")]
        public string Nombres { get; set; } = null!;
        [Column("APELLIDOS")]
        public string Apellidos { get; set; } = null!;
        [Column("FECHA_NACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }
        [Column("NACIONALIDAD")]
        public string Nacionalidad { get; set; } = null!;
        [Column("PASAPORTE")]
        public string Pasaporte { get; set; } = null!;
    }
}