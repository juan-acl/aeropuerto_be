using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("FRECUENCIAS_VUELO")]
    public class FrecuenciaVueloModel
    {
        [Key][Column("ID_FRECUENCIA")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFrecuencia { get; set; }
        [Column("ID_PROGRAMA")]
        public int IdPrograma { get; set; }
        [Column("DIA_SEMANA")][StringLength(15)]
        public string? DiaSemana { get; set; }   // LUNES|MARTES|MIERCOLES|JUEVES|VIERNES|SABADO|DOMINGO
        [Column("HORA_SALIDA")][StringLength(8)]
        public string? HoraSalida { get; set; }
        [Column("HORA_LLEGADA")][StringLength(8)]
        public string? HoraLlegada { get; set; }
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
