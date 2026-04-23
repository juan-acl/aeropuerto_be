using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJERO_MASCOTA")]
    public class PasajeroMascota
    {
        [Key]
        [Column("ID_MASCOTA")]
        public int IdMascota { get; set; }
        [Column("ID_PASAJERO_RESPONSABLE")]
        public int IdPasajeroResponsable { get; set; }
        [Column("NOMBRE_MASCOTA")]
        public string NombreMascota { get; set; } = null!;
        [Column("ESPECIE")]
        public string Especie { get; set; } = null!;
        [Column("RAZA")]
        public string Raza { get; set; } = null!;
        [Column("PESO")]
        public decimal Peso { get; set; }
        [Column("CERTIFICADO_SALUD")]
        public string CertificadoSalud { get; set; } = null!;
    }
}