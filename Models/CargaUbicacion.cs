using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class CargaUbicacion
    {
        [Key]
        public int IdCargaUb { get; set; }
        public int IdEnvio { get; set; }
        public int IdBodega { get; set; }
        public string Pasillo { get; set; } = null!;
        public string Estante { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}