using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("BODEGAS_CARGA")]
    public class BodegaCarga
    {
        [Key]
        [Column("ID_BODEGA")]
        public int id_bodega { get; set; }

        [Column("CODIGO_BODEGA")]
        public string? codigo_bodega { get; set; }

        [Column("NOMBRE_BODEGA")]
        public string? nombre_bodega { get; set; }

        [Column("UBICACION")]
        public string? ubicacion { get; set; }

        [Column("CAPACIDAD_M3")]
        public decimal? capacidad_m3 { get; set; }

        [Column("CAPACIDAD_KG")]
        public decimal? capacidad_kg { get; set; }

        [Column("TIENE_REFRIGERACION")]
        public int? tiene_refrigeracion { get; set; }

        [Column("TEMPERATURA_CONTROLADA")]
        public int? temperatura_controlada { get; set; }

        [Column("TIENE_ACCESO_RESTRINGIDO")]
        public int? tiene_acceso_restringido { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}