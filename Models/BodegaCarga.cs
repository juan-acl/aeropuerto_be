using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("BODEGA_CARGA")]
    public class BodegaCarga
    {
        [Key]
        [Column("ID_BODEGA")]
        public int IdBodega { get; set; }
        [Column("NOMBRE_BODEGA")]
        public string NombreBodega { get; set; } = null!;
        [Column("UBICACION")]
        public string Ubicacion { get; set; } = null!;
        [Column("CAPACIDAD_MAXIMA")]
        public decimal CapacidadMaxima { get; set; }
        [Column("TIPO_CARGA")]
        public string TipoCarga { get; set; } = null!; // PERECEDEROS, PELIGROSA, GENERAL
    }
}