using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class ManifiestoDetalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdManifiesto { get; set; }
        public int IdEnvio { get; set; }
        public string UbicacionBodega { get; set; } = null!;
    }
}