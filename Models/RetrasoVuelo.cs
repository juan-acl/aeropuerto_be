using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("RETRASOS_VUELO")]
    public class RetrasoVueloModel
    {
        [Key][Column("ID_RETRASO")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRetraso { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("MINUTOS_RETRASO")]
        public int? MinutosRetraso { get; set; }
        [Column("TIPO_RETRASO")][StringLength(30)]
        public string? TipoRetraso { get; set; }
        // CLIMATICO|TECNICO|OPERACIONAL|CONTROL_TRAFICO|PROBLEMAS_PASAJE|OTRO
        [Column("CAUSA")][StringLength(500)]
        public string? Causa { get; set; }
        [Column("RESPONSABLE")][StringLength(50)]
        public string? Responsable { get; set; }
        [Column("COMPENSACION_PASAJEROS")]
        public decimal? CompensacionPasajeros { get; set; }
        [Column("FECHA_REGISTRO")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
