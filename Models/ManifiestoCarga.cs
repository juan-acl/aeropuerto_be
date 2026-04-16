using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class ManifiestoCarga
    {
        [Key]
        public int IdManifiesto { get; set; }
        public int IdVuelo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } = "CERRADO";
        public decimal PesoTotal { get; set; }
    }
}