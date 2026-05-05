using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("HANGARES")]
    public class HangarModel
    {
        [Key][Column("ID_HANGAR")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHangar { get; set; }
        [Column("CODIGO_AEROPUERTO")][StringLength(10)]
        public string? CodigoAeropuerto { get; set; }
        [Column("NOMBRE_HANGAR")][StringLength(50)]
        public string NombreHangar { get; set; } = null!;
        [Column("CAPACIDAD_AVIONES")]
        public int? CapacidadAviones { get; set; }
        [Column("AREA_M2")]
        public decimal? AreaM2 { get; set; }
        [Column("TIPO_HANGAR")][StringLength(30)]
        public string? TipoHangar { get; set; }  // MANTENIMIENTO|ALMACENAMIENTO|OPERACIONES
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
