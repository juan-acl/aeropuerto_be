using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("HOTELES_CERCANOS")]
    public class HotelesCercanosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_HOTEL")]
        public int IdHotel { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("NOMBRE_HOTEL")]
        public string? NombreHotel { get; set; }

        [Column("CATEGORIA")]
        public string Categoria { get; set; } = null!; // 1*, 2*, 3*, 4*, 5*

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

        [Column("DISTANCIA_KM")]
        public decimal? DistanciaKm { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("WEBSITE")]
        public string? Website { get; set; }

        [Column("TARIFA_NOCHE_DESDE")]
        public decimal? TarifaNocheDesde { get; set; }

        [Column("TIENE_SHUTTLE")]
        public int TieneShuttle { get; set; } = 0;

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
