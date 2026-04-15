using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("PUERTAS_EMBARQUE")]
    public class PuertaEmbarqueModel
    {
        [Key][Column("ID_PUERTA")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPuerta { get; set; }
        [Column("CODIGO_AEROPUERTO")][StringLength(10)]
        public string? CodigoAeropuerto { get; set; }
        [Column("NUMERO_PUERTA")][StringLength(10)]
        public string? NumeroPuerta { get; set; }
        [Column("TERMINAL")][StringLength(10)]
        public string? Terminal { get; set; }
        [Column("TIPO_PUERTA")][StringLength(20)]
        public string? TipoPuerta { get; set; }   // NACIONAL|INTERNACIONAL|MIXTA
        [Column("CAPACIDAD_MAXIMA")]
        public int? CapacidadMaxima { get; set; }
        [Column("TIENE_PASARELA")]
        public int TienePasarela { get; set; } = 0;
        [Column("ESTADO_OPERACIONAL")][StringLength(20)]
        public string EstadoOperacional { get; set; } = "DISPONIBLE";
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
