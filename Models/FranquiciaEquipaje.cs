using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("FRANQUICIAS_EQUIPAJE")]
    public class FranquiciaEquipajeModel
    {
        [Key][Column("ID_FRANQUICIA")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFranquicia { get; set; }
        [Column("ID_AEROLINEA")]
        public int IdAerolinea { get; set; }
        [Column("CLASE_SERVICIO")][StringLength(20)]
        public string? ClaseServicio { get; set; }
        [Column("PESO_MAXIMO_KG")]
        public decimal? PesoMaximoKg { get; set; }
        [Column("PIEZAS_PERMITIDAS")]
        public int? PiezasPermitidas { get; set; }
        [Column("DIMENSIONES_MAXIMAS_CM")][StringLength(30)]
        public string? DimensionesMaximasCm { get; set; }
        [Column("EXCESO_EQUIPAJE_COSTO")]
        public decimal? ExcesoEquipajeCosto { get; set; }
        [Column("MONEDA")][StringLength(5)]
        public string? Moneda { get; set; }
    }
}
