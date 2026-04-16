using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class PasajeroMascota
    {
        [Key]
        public int IdMascota { get; set; }
        public int IdPasajeroResponsable { get; set; }
        public string NombreMascota { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public decimal Peso { get; set; }
        public string CertificadoSalud { get; set; } = null!;
    }
}