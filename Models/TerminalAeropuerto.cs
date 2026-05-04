using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("TERMINALES_AEROPUERTO")]
    public class TerminalAeropuertoModel
    {
        [Key][Column("ID_TERMINAL")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTerminal { get; set; }
        [Column("CODIGO_AEROPUERTO")][StringLength(10)]
        public string? CodigoAeropuerto { get; set; }
        [Column("NOMBRE_TERMINAL")][StringLength(50)]
        public string NombreTerminal { get; set; } = null!;
        [Column("TIPO_TERMINAL")][StringLength(20)]
        public string? TipoTerminal { get; set; }  // NACIONAL|INTERNACIONAL|MIXTA|CARGA
        [Column("CAPACIDAD_PASAJEROS")]
        public int? CapacidadPasajeros { get; set; }
        [Column("AREA_M2")]
        public decimal? AreaM2 { get; set; }
        [Column("NUMERO_PUERTAS")]
        public int? NumeroPuertas { get; set; }
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
